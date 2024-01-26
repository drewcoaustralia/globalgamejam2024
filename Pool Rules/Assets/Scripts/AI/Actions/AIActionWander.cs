using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TestTools;

public class AIActionWander : AIAction
{
    [SerializeField] private NavMeshAgent childsNavMeshAgent;
    [SerializeField] private float moveRange = 10f;

    private void Awake()
    {
        if (childsNavMeshAgent == null) Debug.LogWarning("childsNavMeshAgent is null");
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