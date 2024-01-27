using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDecisionSwimming : AIDecision
{
    [SerializeField] private ChildRuleStates childRuleStates;

    private void Awake()
    {
        if (childRuleStates == null) childRuleStates = GetComponentInParent<ChildRuleStates>();
        if (childRuleStates == null) Debug.LogWarning("childRuleStates is null");
    }

    public override bool Decide()
    {
        if (childRuleStates.IsSwimming) return true;
        else return false;
    }
}
