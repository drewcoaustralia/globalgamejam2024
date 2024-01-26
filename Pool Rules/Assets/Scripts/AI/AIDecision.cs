using UnityEngine;

public abstract class AIDecision : MonoBehaviour
{
    public abstract bool Decide();

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
