using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIActionDrowning : AIAction
{
    [SerializeField] private ChildRuleStates childRuleStates;
    [SerializeField] private NavMeshAgent childNavMeshAgent;
    [SerializeField] private float drowningBaseOffset = 0.15f;

    private float originalBaseOffset;

    private void Awake()
    {
        if (childNavMeshAgent == null) childNavMeshAgent = GetComponentInParent<NavMeshAgent>();
        if (childNavMeshAgent == null) Debug.LogWarning("childNavMeshAgent is null");
        if (childRuleStates == null) childRuleStates = GetComponentInParent<ChildRuleStates>();
        if (childRuleStates == null) Debug.LogWarning("childRuleStates is null");
    }

    private void Start()
    {
        originalBaseOffset = childNavMeshAgent.baseOffset;
    }

    public override void OnEnterState()
    {
        base.OnEnterState();
        childNavMeshAgent.baseOffset = drowningBaseOffset;
        ChildAnimationController animator = childNavMeshAgent.gameObject.GetComponent<ChildAnimationController>();
        animator.ChangeIdlingState("drowning");
        animator.SetAnimation("drowning");
    }

    public override void OnExitState()
    {
        base.OnExitState();
        childNavMeshAgent.baseOffset = originalBaseOffset;
    }

    public override void PerformAction()
    {
        if (childNavMeshAgent.isActiveAndEnabled)
        {
            childRuleStates.IsDrowning = true;
        }
    }
}
