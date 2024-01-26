using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Maths
{
    public static int RollADice(int numberOfSides)
    {
        return (UnityEngine.Random.Range(1, numberOfSides + 1));
    }
}
