using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : Singleton<ScoreManager>
{
    public AudioClip lifeLostSFX;
    public UnityEvent onFirstLifeLost;
    public UnityEvent onSecondLifeLost;
    public UnityEvent onThirdLifeLost;
    public UnityEvent onGameOver;

    private int _score = 0;
    private int _fails = 0;

    public void AddScore()
    {
        _score++;
    }

    public void LoseLife()
    {
        _fails++;
        if (lifeLostSFX != null) AudioManager.Instance.PlayAudio(lifeLostSFX, 1.25f);

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
            onGameOver.Invoke();
        }
    }
}
