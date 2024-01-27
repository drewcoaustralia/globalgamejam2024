using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TestTools;

public class AIActionWander : AIAction
{
    [SerializeField] private NavMeshAgent childNavMeshAgent;
    [SerializeField] private float moveRange = 10f;

    private void Awake()
    {
        if (childNavMeshAgent == null) childNavMeshAgent = GetComponentInParent<NavMeshAgent>();
        if (childNavMeshAgent == null) Debug.LogWarning("childNavMeshAgent is null");
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
