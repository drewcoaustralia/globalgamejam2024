using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDecisionTriggered : AIDecision
{
    private bool _transitionOut = false;

    public override bool Decide()
    {
        return _transitionOut;
    }

    public override void OnExitState()
    {
        base.OnExitState();
        _transitionOut = false;
    }

    public void TransitionOut()
    {
        _transitionOut = true;
    }
}
