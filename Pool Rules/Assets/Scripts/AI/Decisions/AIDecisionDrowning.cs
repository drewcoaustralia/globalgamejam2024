using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDecisionDrowning : AIDecision
{
    [SerializeField] private Child child;
    [SerializeField] private int totalChance = 100;
    [SerializeField] private int odds = 1;
    [SerializeField] private bool logDiceRolls = false;

    private void Awake()
    {
        if (child == null) Debug.LogWarning("child is null");
    }

    public override bool Decide()
    {
        if (child.IsSwimming)
        {
            return EvaluateOdds();
        }
        else return false;
    }

    private bool EvaluateOdds()
    {
        int dice = Maths.RollADice(totalChance);
        bool result = (dice <= odds);
        if (logDiceRolls)
        {
            Debug.Log("Rolled a dice with " + totalChance + " sides. Rolled: " + dice +
                      " - Comparing rolled value (" + dice + ") to odds (" + odds + "). Result: " + result);
        }
        return result;
    }
}
