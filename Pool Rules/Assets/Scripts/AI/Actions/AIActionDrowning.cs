using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIActionDrowning : AIAction
{
    [SerializeField] private ChildRuleStates childRuleStates;

    private void Awake()
    {
        if (childRuleStates == null) Debug.LogWarning("childRuleStates is null");
    }

    public override void PerformAction()
    {
        childRuleStates.IsDrowning = true;
    }
}
