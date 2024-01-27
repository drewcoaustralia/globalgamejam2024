using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIActionSwimming : AIAction
{
    [SerializeField] private ChildRuleStates childRuleStates;
    [SerializeField] private NavMeshAgent childNavMeshAgent;
    [SerializeField] private float swimmingSpeed = 2f;
    [SerializeField] private float swimmingBaseOffset = 0.3f;
    [SerializeField] private float moveRange = 10f;

    private float originalSpeed;
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
        originalSpeed = childNavMeshAgent.speed;
        originalBaseOffset = childNavMeshAgent.baseOffset;
    }

    public override void OnEnterState()
    {
        base.OnEnterState();
        childNavMeshAgent.speed = swimmingSpeed;
        childNavMeshAgent.baseOffset = swimmingBaseOffset;
    }

    public override void OnExitState()
    {
        base.OnExitState();
        childNavMeshAgent.speed = originalSpeed;
        childNavMeshAgent.baseOffset = originalBaseOffset;
    }

    public override void PerformAction()
    {
        if (childNavMeshAgent.isActiveAndEnabled && !childNavMeshAgent.pathPending)
        {
            if (childNavMeshAgent.remainingDistance < 0.1f)
            {
                MoveToRandomTarget();
            }
        }
    }

    private void MoveToRandomTarget()
    {
        Vector3 randomDirection = Random.insideUnitSphere * moveRange;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, moveRange, NavMesh.AllAreas);
        childNavMeshAgent.SetDestination(hit.position);
    }
}
