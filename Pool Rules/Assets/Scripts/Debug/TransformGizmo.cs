using UnityEngine;

public class TransformGizmo : MonoBehaviour
{
    public Color gizmoColor = Color.yellow;
    public bool showGizmo = true;

    private void OnDrawGizmos()
    {
        if (!showGizmo)
            return;

        Gizmos.color = gizmoColor;
        Gizmos.DrawSphere(transform.position, 0.1f);
    }
}
