using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class AIDecisionRandom : AIDecision
{
    [SerializeField] private int totalChance = 10;
    [SerializeField] private int odds = 4;

    public override bool Decide()
    {
        return EvaluateOdds();
    }

    private bool EvaluateOdds()
    {
        int dice = Maths.RollADice(totalChance);
        bool result = (dice <= odds);
        return result;
    }
}
