using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIActionRunning : AIAction
{
    [SerializeField] private ChildRuleStates childRuleStates;
    [SerializeField] private NavMeshAgent childsNavMeshAgent;
    [SerializeField] private float runningSpeed = 10f;
    [SerializeField] private float moveRange = 10f;

    private float originalSpeed;

    private void Awake()
    {
        if (childRuleStates == null) Debug.LogWarning("childsRuleStates is null");
        if (childsNavMeshAgent == null) Debug.LogWarning("navMeshAgent is null");
    }

    private void Start()
    {
        originalSpeed = childsNavMeshAgent.speed;
    }

    public override void OnEnterState()
    {
        base.OnEnterState();
        childsNavMeshAgent.speed = runningSpeed;
    }

    public override void OnExitState()
    {
        base.OnExitState();
        childsNavMeshAgent.speed = originalSpeed;
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