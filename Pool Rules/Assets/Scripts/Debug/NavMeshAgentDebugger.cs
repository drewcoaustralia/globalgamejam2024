using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshAgentDebugger : MonoBehaviour
{
    [SerializeField] private bool showPathGizmo = true;
    [SerializeField] private bool showDestinationGizmo = true;

    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void OnDrawGizmos()
    {
        if (navMeshAgent == null || navMeshAgent.path == null)
            return;

        if (showPathGizmo)
        {
            DrawPathGizmo(navMeshAgent.path);
        }

        if (showDestinationGizmo)
        {
            DrawDestinationGizmo(navMeshAgent.destination);
        }
    }

    private void DrawPathGizmo(NavMeshPath path)
    {
        Gizmos.color = Color.magenta;

        for (int i = 0; i < path.corners.Length - 1; i++)
        {
            Gizmos.DrawLine(path.corners[i], path.corners[i + 1]);
        }
    }

    private void DrawDestinationGizmo(Vector3 destination)
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(destination, 0.1f);
    }
}
