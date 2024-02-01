using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AIActionStart : AIAction
{
    [SerializeField] private ChildRuleStates childRuleStates;
    [SerializeField] private NavMeshAgent childNavMeshAgent;
    [SerializeField] private AIDecisionTriggered aiDecisionTriggered;

    private GameObject _firstNode;
    private GameObject _secondNode;
    private bool _isMovingToNode = false;
    private bool _hasReachedFirstNode = false;
    private bool _hasReachedSecondNode = false;
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
        _firstNode = StartNodeManager.Instance.startNode;
        _secondNode = StartNodeManager.Instance.GetRandomNode();
    }

    public override void OnEnterState()
    {
        base.OnEnterState();
        _isMovingToNode = false;
        _originalStoppingDistance = childNavMeshAgent.stoppingDistance;
    }

    public override void PerformAction()
    {
        if (!_isMovingToNode && !_hasReachedFirstNode)
        {
            MoveToFirstNode();
        }
        else if (_hasReachedFirstNode && !_isMovingToNode)
        {
            MoveToSecondNode();
        }
        else if (_hasReachedSecondNode)
        {
            TransitionOut();
        }
    }

    private void MoveToFirstNode()
    {
        if (childNavMeshAgent.isActiveAndEnabled)
        {
            childNavMeshAgent.stoppingDistance = 5.0f;
            childNavMeshAgent.SetDestination(_firstNode.transform.position);
            _isMovingToNode = true;

            StartCoroutine(FirstMoveCoroutine());
            //StartCoroutine(ForceTransitionOutAfterDelay(12.0f));
        }
    }

    private IEnumerator FirstMoveCoroutine()
    {
        yield return new WaitForSeconds(0.1f);

        if (_firstNode != null && childNavMeshAgent.isActiveAndEnabled)
        {
            while (childNavMeshAgent.pathPending || (childNavMeshAgent.isActiveAndEnabled && childNavMeshAgent.remainingDistance > childNavMeshAgent.stoppingDistance))
            {
                yield return null;
            }

            //TransitionOut();
            //Debug.Log("reached first node");
            _hasReachedFirstNode = true;
            _isMovingToNode = false;
        }
    }

    private void MoveToSecondNode()
    {
        if (childNavMeshAgent.isActiveAndEnabled)
        {
            childNavMeshAgent.stoppingDistance = 5.0f;
            childNavMeshAgent.SetDestination(_secondNode.transform.position);
            _isMovingToNode = true;

            StartCoroutine(SecondMoveCoroutine());
            //StartCoroutine(ForceTransitionOutAfterDelay(12.0f));
        }
    }

    private IEnumerator SecondMoveCoroutine()
    {
        yield return new WaitForSeconds(0.1f);

        if (_firstNode != null && childNavMeshAgent.isActiveAndEnabled)
        {
            while (childNavMeshAgent.pathPending || (childNavMeshAgent.isActiveAndEnabled && childNavMeshAgent.remainingDistance > childNavMeshAgent.stoppingDistance))
            {
                yield return null;
            }

            //Debug.Log("reached second node");
            _hasReachedSecondNode = true;
            _isMovingToNode = false;
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
