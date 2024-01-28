using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : Singleton<ScoreManager>
{
    public UnityEvent onFirstLifeLost;
    public UnityEvent onSecondLifeLost;
    public UnityEvent onThirdLifeLost;

    private int _score = 0;
    private int _fails = 0;

    public void AddScore()
    {
        _score++;
    }

    public void LoseLife()
    {
        _fails++;

        if (_fails == 1)
        {
            onFirstLifeLost.Invoke();
        }
        else if (_fails == 2)
        {
            onSecondLifeLost.Invoke();
        }
        else if (_fails == 3)
        {
            onThirdLifeLost.Invoke();
        }
    }
}
