using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ScheduledRuleChange
{
    public bool started = false;
    public string ruleName;
    public float startTime;
    public float timer;
    public AudioClip sting;

    public ScheduledRuleChange(string ruleName, float startTime, float timer, AudioClip sting)
    {
        started = false;
        this.ruleName = ruleName;
        this.startTime = startTime;
        this.timer = timer;
        this.sting = sting;
    }

    public bool ShouldStart()
    {
        return (!started && Time.timeSinceLevelLoad >= startTime);
    }

    public bool IsTimeElapsed()
    {
        return Time.timeSinceLevelLoad >= startTime + timer;
    }
}

public class RuleScheduler : MonoBehaviour
{
    public List<ScheduledRuleChange> scheduledChanges;

    private RuleManager _ruleManager;

    public AudioClip defaultSting;

    void Start()
    {
        _ruleManager = RuleManager.Instance;
    }

    void Update()
    {
        for (int i = scheduledChanges.Count - 1; i >= 0; i--)
        {
            ScheduledRuleChange change = scheduledChanges[i];
            if (change.ShouldStart())
            {
                change.started = true;
                Debug.Log("starting rule " + change.ruleName);
                _ruleManager.SetRule(change.ruleName, true);
                if (change.sting != null) AudioManager.Instance.PlayAudio(change.sting);
                else AudioManager.Instance.PlayAudio(defaultSting);
            }

            if (change.IsTimeElapsed())
            {
                _ruleManager.SetRule(change.ruleName, false);
                scheduledChanges.RemoveAt(i);
            }
        }
    }
}