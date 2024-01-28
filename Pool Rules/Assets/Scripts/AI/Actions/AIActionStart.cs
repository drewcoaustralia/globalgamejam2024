using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIActionStart : AIAction
{
    [SerializeField] private ChildRuleStates childRuleStates;
    [SerializeField] private NavMeshAgent childNavMeshAgent;
    [SerializeField] private AIDecisionTriggered aiDecisionTriggered;

    private GameObject _moveToNode;
    private bool _isMovingToNode = false;
    private float _originalStoppingDistance;

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
        _moveToNode = StartNodeManager.Instance.startNode;
    }

    public override void OnEnterState()
    {
        base.OnEnterState();
        _isMovingToNode = false;
        _originalStoppingDistance = childNavMeshAgent.stoppingDistance;
    }

    public override void PerformAction()
    {
        if (!_isMovingToNode)
        {
            MoveToNode();
        }
    }

    private void MoveToNode()
    {
        if (childNavMeshAgent.isActiveAndEnabled)
        {
            childNavMeshAgent.stoppingDistance = 5.0f;
            childNavMeshAgent.SetDestination(_moveToNode.transform.position);
            _isMovingToNode = true;

            //StartCoroutine(MoveCoroutine());
            StartCoroutine(ForceTransitionOutAfterDelay(12.0f));
        }
    }

    private IEnumerator MoveCoroutine()
    {
        yield return new WaitForSeconds(0.1f);

        if (_moveToNode != null && childNavMeshAgent.isActiveAndEnabled)
        {
            while (childNavMeshAgent.pathPending || (childNavMeshAgent.isActiveAndEnabled && childNavMeshAgent.remainingDistance > childNavMeshAgent.stoppingDistance))
            {
                yield return null;
            }

            TransitionOut();
        }
    }

    private void TransitionOut()
    {
        aiDecisionTriggered.TransitionOut();
    }

    private IEnumerator ForceTransitionOutAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (_isMovingToNode)
        {
            TransitionOut();
        }
    }

    public override void OnExitState()
    {
        base.OnExitState();

        if (childNavMeshAgent.isActiveAndEnabled)
        {
            childNavMeshAgent.ResetPath();
        }

        childNavMeshAgent.stoppingDistance = _originalStoppingDistance;
    }
}
