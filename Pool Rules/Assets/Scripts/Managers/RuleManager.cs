using System;
using System.Collections.Generic;

public class RuleManager : Singleton<RuleManager>
{
    public event Action<string, bool> RuleChanged;

    private Dictionary<string, bool> rules = new Dictionary<string, bool>();

    public void SetRule(string ruleName, bool isActive)
    {
        if (!rules.ContainsKey(ruleName) || rules[ruleName] != isActive)
        {
            rules[ruleName] = isActive;
            RuleChanged?.Invoke(ruleName, isActive);
        }
    }

    public bool GetRule(string ruleName)
    {
        return rules.TryGetValue(ruleName, out bool isActive) ? isActive : false;
    }
}
