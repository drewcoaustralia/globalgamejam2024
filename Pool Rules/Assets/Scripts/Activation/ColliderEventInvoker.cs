using UnityEngine;
using UnityEngine.Events;

public class ColliderEventInvoker : MonoBehaviour
{
    public LayerMask targetLayer;
    public UnityEvent onEnter;
    public UnityEvent onExit;
    public UnityEvent onStay;

    private void OnTriggerEnter(Collider other)
    {
        if ((targetLayer.value & (1 << other.gameObject.layer)) != 0)
        {
            onEnter.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ((targetLayer.value & (1 << other.gameObject.layer)) != 0)
        {
            onExit.Invoke();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if ((targetLayer.value & (1 << other.gameObject.layer)) != 0)
        {
            onStay.Invoke();
        }
    }
}
