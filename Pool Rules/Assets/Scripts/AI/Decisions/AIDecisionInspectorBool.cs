using UnityEngine;

public class AIDecisionInspectorBool : AIDecision
{
    [SerializeField] private bool shouldTransition;

    public override bool Decide()
    {
        return shouldTransition;
    }
}
