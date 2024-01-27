using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RuleManager : Singleton<RuleManager>
{
    public event Action<string, bool> RuleChanged;

    [SerializeField] private bool logRuleChanges;

    private Dictionary<string, bool> rules = new Dictionary<string, bool>();

    public TextMeshProUGUI signLeft;
    public TextMeshProUGUI signRight;

    public void SetRule(string ruleName, bool isActive)
    {
        if (!rules.ContainsKey(ruleName) || rules[ruleName] != isActive)
        {
            rules[ruleName] = isActive;
            RuleChanged?.Invoke(ruleName, isActive);
            if (logRuleChanges) Debug.Log($"{ruleName} set to {isActive}");
            // do UI stuff here
            signLeft.text += "\n-" + ruleName;
        }
    }

    public bool GetRule(string ruleName)
    {
        return rules.TryGetValue(ruleName, out bool isActive) ? isActive : false;
    }
}
