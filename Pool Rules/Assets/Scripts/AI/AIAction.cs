using UnityEngine;

public abstract class AIAction : MonoBehaviour
{
    [SerializeField] private bool logStateChange = false;

    public abstract void PerformAction();

    public virtual void Initialization()
    {
    }

    public virtual void OnEnterState()
    {
        if (logStateChange) Debug.Log($"transitioned to {GetType().Name}.");
    }

    public virtual void OnExitState()
    {
        if (logStateChange) Debug.Log($"transitioned from {GetType().Name}.");
    }
}
