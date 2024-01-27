using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDecisionSwimming : AIDecision
{
    [SerializeField] private ChildRuleStates childRuleStates;

    private void Awake()
    {
        if (childRuleStates == null) Debug.LogWarning("ChildRuleStates is null");
    }

    public override bool Decide()
    {
        if (childRuleStates.IsSwimming) return true;
        else return false;
    }
}
