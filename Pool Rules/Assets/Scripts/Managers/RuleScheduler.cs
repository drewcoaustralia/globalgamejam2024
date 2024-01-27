using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ScheduledRuleChange
{
    public string ruleName;
    public float changeTime;
    public bool newState;
}

public class RuleScheduler : MonoBehaviour
{
    public List<ScheduledRuleChange> scheduledChanges;

    private RuleManager _ruleManager;
    private float _gameTime;

    void Start()
    {
        _ruleManager = RuleManager.Instance;
        _gameTime = 0f;
    }

    void Update()
    {
        _gameTime += Time.deltaTime;

        for (int i = 0; i < scheduledChanges.Count; i++)
        {
            ScheduledRuleChange change = scheduledChanges[i];
            if (_gameTime >= change.changeTime)
            {
                _ruleManager.SetRule(change.ruleName, change.newState);
                scheduledChanges.RemoveAt(i);
                i--;
            }
        }
    }
}
