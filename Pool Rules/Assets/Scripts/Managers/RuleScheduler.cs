using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ScheduledRuleChange
{
    public string ruleName;
    public float startTime;
    public float timer;

    public ScheduledRuleChange(string ruleName, float startTime, float timer)
    {
        this.ruleName = ruleName;
        this.startTime = startTime;
        this.timer = timer;
    }

    public bool ShouldStart()
    {
        return Time.time >= startTime;
    }

    public bool IsTimeElapsed()
    {
        return Time.time >= startTime + timer;
    }
}

public class RuleScheduler : MonoBehaviour
{
    public List<ScheduledRuleChange> scheduledChanges;

    private RuleManager _ruleManager;

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
                _ruleManager.SetRule(change.ruleName, true);
            }

            if (change.IsTimeElapsed())
            {
                _ruleManager.SetRule(change.ruleName, false);
                scheduledChanges.RemoveAt(i);
            }
        }
    }
}