using UnityEngine;

public abstract class AIAction : MonoBehaviour
{
    public abstract void PerformAction();

    public virtual void Initialization()
    {
    }

    public virtual void OnEnterState()
    {
    }

    public virtual void OnExitState()
    {
    }
}
