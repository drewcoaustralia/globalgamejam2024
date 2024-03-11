using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIActionRunning : AIAction
{
    [SerializeField] private ChildRuleStates childRuleStates;
    [SerializeField] private NavMeshAgent childNavMeshAgent;
    [SerializeField] private float runningSpeed = 10f;
    [SerializeField] private float moveRange = 10f;

    private float originalSpeed;
    private ChildAnimationController animController;

    private void Awake()
    {
        if (childNavMeshAgent == null) childNavMeshAgent = GetComponentInParent<NavMeshAgent>();
        if (childNavMeshAgent == null) Debug.LogWarning("childNavMeshAgent is null");
        if (childRuleStates == null) childRuleStates = GetComponentInParent<ChildRuleStates>();
        if (childRuleStates == null) Debug.LogWarning("childRuleStates is null");
        animController = GetComponentInParent<ChildAnimationController>();
    }

    private void Start()
    {
        originalSpeed = childNavMeshAgent.speed;
    }

    public override void OnEnterState()
    {
        base.OnEnterState();
        childNavMeshAgent.speed = runningSpeed;
        animController.SetAnimationSpeed(runningSpeed / originalSpeed);
    }

    public override void OnExitState()
    {
        base.OnExitState();
        childNavMeshAgent.speed = originalSpeed;
        animController.SetAnimationSpeed(1);
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