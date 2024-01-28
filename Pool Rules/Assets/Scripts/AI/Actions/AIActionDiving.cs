using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AIActionDiving : AIAction
{
    [SerializeField] private ChildRuleStates childRuleStates;
    [SerializeField] private NavMeshAgent childNavMeshAgent;
    [SerializeField] private AIDecisionTriggered aiDecisionTriggered;

    private DivingNodeManager _divingNodeManager;
    private GameObject _nearestDivingNode;
    private bool _isMovingToNode = false;

    private void Awake()
    {
        if (childNavMeshAgent == null) childNavMeshAgent = GetComponentInParent<NavMeshAgent>();
        if (childRuleStates == null) childRuleStates = GetComponentInParent<ChildRuleStates>();
        if (childNavMeshAgent == null) Debug.LogWarning("childNavMeshAgent is null");
        if (childRuleStates == null) Debug.LogWarning("childRuleStates is null");
        if (aiDecisionTriggered == null) Debug.LogWarning("aiDecisionTriggered is null");
    }

    private void Start()
    {
        _divingNodeManager = DivingNodeManager.Instance;
    }

    public override void OnEnterState()
    {
        base.OnEnterState();
        _nearestDivingNode = null;
        _isMovingToNode = false;
    }

    public override void PerformAction()
    {
        if (!_isMovingToNode)
        {
            MoveToNearestDivingNode();
        }
    }

    private void MoveToNearestDivingNode()
    {
        _nearestDivingNode = _divingNodeManager.FindClosestNode(transform.position);

        if (childNavMeshAgent.isActiveAndEnabled)
        {
            childNavMeshAgent.SetDestination(_nearestDivingNode.transform.position);
            _isMovingToNode = true;
            StartCoroutine(DiveCoroutine());
        }
    }

    private IEnumerator DiveCoroutine()
    {
        yield return new WaitForSeconds(0.1f);

        if (_nearestDivingNode != null && childNavMeshAgent.isActiveAndEnabled)
        {
            // Wait until we have reached the diving node
            while (childNavMeshAgent.pathPending || (childNavMeshAgent.isActiveAndEnabled && childNavMeshAgent.remainingDistance > childNavMeshAgent.stoppingDistance))
            {
                yield return null;
            }

            childRuleStates.IsDiving = true;

            // Move to the child landing node
            Transform child = _nearestDivingNode.transform.GetChild(0);
            if (childNavMeshAgent.isActiveAndEnabled)
            {
                childNavMeshAgent.SetDestination(child.position);
            }

            // Wait until we have reached the child landing node
            while (childNavMeshAgent.pathPending || (childNavMeshAgent.isActiveAndEnabled && childNavMeshAgent.remainingDistance > childNavMeshAgent.stoppingDistance))
            {
                yield return null;
            }

            childRuleStates.IsDiving = false;
            TransitionOut();
        }
    }

    private void TransitionOut()
    {
        aiDecisionTriggered.TransitionOut();
    }
}
