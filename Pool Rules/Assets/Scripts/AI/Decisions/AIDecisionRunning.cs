using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDecisionRunning : AIDecision
{
    [SerializeField] private ChildRuleStates childRuleStates;
    [SerializeField] private int totalChance = 25;
    [SerializeField] private int odds = 1;

    private void Awake()
    {
        if (childRuleStates == null) Debug.LogWarning("ChildRuleStates is null");
    }

    public override bool Decide()
    {
        if (childRuleStates.IsSwimming) return false;
        else return EvaluateOdds();
    }

    private bool EvaluateOdds()
    {
        int dice = Maths.RollADice(totalChance);
        bool result = (dice <= odds);
        return result;
    } 
}
