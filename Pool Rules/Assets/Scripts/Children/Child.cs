using UnityEngine;
using UnityEngine.Events;

public class Child : MonoBehaviour
{
    public UnityEvent onRuleBroken;
    public UnityEvent onRuleNoLongerBroken;

    private RuleManager ruleManager;
    private bool hasBrokenARule;
    private bool isSwimming;
    private bool isDrowning;
    private bool isRunning;

    public bool HasBrokenARule
    {
        get { return hasBrokenARule; }
        private set
        {
            if (hasBrokenARule != value)
            {
                hasBrokenARule = value;

                if (hasBrokenARule)
                {
                    onRuleBroken.Invoke();
                }
                else onRuleNoLongerBroken.Invoke();
            }
        }
    }

    public bool IsSwimming
    {
        get { return isSwimming; }
        set
        {
            if (isSwimming != value)
            {
                isSwimming = value;
                CheckForRuleViolation();
            }
        }
    }

    public bool IsDrowning
    {
        get { return isDrowning; }
        set
        {
            if (isDrowning != value)
            {
                isDrowning = value;
                CheckForRuleViolation();
            }
        }
    }

    public bool IsRunning
    {
        get { return isRunning; }
        set
        {
            if (isRunning != value)
            {
                isRunning = value;
                CheckForRuleViolation();
            }
        }
    }

    private void Start()
    {
        ruleManager = RuleManager.Instance;
        ruleManager.RuleChanged += OnRuleChanged;
    }

    private void OnDestroy()
    {
        ruleManager.RuleChanged -= OnRuleChanged;
    }

    private void OnRuleChanged(string ruleName, bool isActive)
    {
        CheckForRuleViolation();
    }

    private void CheckForRuleViolation()
    {
        bool swimmingRule = ruleManager.GetRule("NoSwimming");
        bool runningRule = ruleManager.GetRule("NoRunning");
        bool drowningRule = ruleManager.GetRule("NoDrowning");

        if ((swimmingRule && IsSwimming) ||
            (runningRule && IsRunning) ||
            (drowningRule && IsDrowning))
        {
            HasBrokenARule = true;
        }
    }
}
