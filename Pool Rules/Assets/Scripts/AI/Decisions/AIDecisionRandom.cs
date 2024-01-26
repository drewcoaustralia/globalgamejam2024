using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class AIDecisionRandom : AIDecision
{
    [SerializeField] private int TotalChance = 10;
    [SerializeField] private int Odds = 4;

    public override bool Decide()
    {
        return EvaluateOdds();
    }

    protected virtual bool EvaluateOdds()
    {
        int dice = Maths.RollADice(TotalChance);
        bool result = (dice <= Odds);
        return result;
    }
}
