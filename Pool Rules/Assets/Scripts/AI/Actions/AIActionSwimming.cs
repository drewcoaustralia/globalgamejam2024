using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIActionSwimming : AIAction
{
    [SerializeField] private ChildRuleStates childRuleStates;
    [SerializeField] private NavMeshAgent childsNavMeshAgent;
    [SerializeField] private float swimmingSpeed = 2f;
    [SerializeField] private float swimmingBaseOffset = 0.3f;
    [SerializeField] private float moveRange = 10f;

    private float originalSpeed;
    private float originalBaseOffset;

    private void Awake()
    {
        if (childRuleStates == null) Debug.LogWarning("childsRuleStates is null");
        if (childsNavMeshAgent == null) Debug.LogWarning("navMeshAgent is null");
    }

    private void Start()
    {
        originalSpeed = childsNavMeshAgent.speed;
        originalBaseOffset = childsNavMeshAgent.baseOffset;
    }

    public override void OnEnterState()
    {
        base.OnEnterState();
        childsNavMeshAgent.speed = swimmingSpeed;
        childsNavMeshAgent.baseOffset = swimmingBaseOffset;
    }

    public override void OnExitState()
    {
        base.OnExitState();
        childsNavMeshAgent.speed = originalSpeed;
        childsNavMeshAgent.baseOffset = originalBaseOffset;
    }

    public override void PerformAction()
    {
        if (!childsNavMeshAgent.pathPending && childsNavMeshAgent.remainingDistance < 0.1f)
        {
            MoveToRandomTarget();
        }
    }

    private void MoveToRandomTarget()
    {
        Vector3 randomDirection = Random.insideUnitSphere * moveRange;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, moveRange, NavMesh.AllAreas);
        childsNavMeshAgent.SetDestination(hit.position);
    }
}
