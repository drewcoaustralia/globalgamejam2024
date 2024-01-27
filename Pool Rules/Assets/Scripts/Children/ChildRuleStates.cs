using UnityEngine;
using UnityEngine.Events;

public class ChildRuleStates : MonoBehaviour
{
    public UnityEvent onRuleBroken;
    public UnityEvent onRuleNoLongerBroken;

    private RuleManager _ruleManager;
    private bool _hasBrokenARule;
    private bool _isSwimming;
    private bool _isDrowning;
    private bool _isRunning;
    private bool _isFlipping;
    private bool _isEatingOrDrinking;
    private bool _isSmiling;
    private bool _isDiving;
    private bool _isWalking;

    public bool HasBrokenARule
    {
        get { return _hasBrokenARule; }
        private set
        {
            if (_hasBrokenARule != value)
            {
                _hasBrokenARule = value;

                if (_hasBrokenARule)
                {
                    onRuleBroken.Invoke();
                }
                else onRuleNoLongerBroken.Invoke();
            }
        }
    }

    public bool IsSwimming
    {
        get { return _isSwimming; }
        set { SetProperty(ref _isSwimming, value); }
    }

    public bool IsDrowning
    {
        get { return _isDrowning; }
        set { SetProperty(ref _isDrowning, value); }
    }

    public bool IsRunning
    {
        get { return _isRunning; }
        set { SetProperty(ref _isRunning, value); }
    }

    public bool IsFlipping
    {
        get { return _isFlipping; }
        set { SetProperty(ref _isFlipping, value); }
    }

    public bool IsEatingOrDrinking
    {
        get { return _isEatingOrDrinking; }
        set { SetProperty(ref _isEatingOrDrinking, value); }
    }

    public bool IsSmiling
    {
        get { return _isSmiling; }
        set { SetProperty(ref _isSmiling, value); }
    }

    public bool IsDiving
    {
        get { return _isDiving; }
        set { SetProperty(ref _isDiving, value); }
    }

    public bool IsWalking
    {
        get { return _isWalking; }
        set { SetProperty(ref _isWalking, value); }
    }

    private void SetProperty(ref bool field, bool value)
    {
        if (field != value)
        {
            field = value;
            CheckForRuleViolation();
        }
    }

    private void Start()
    {
        _ruleManager = RuleManager.Instance;
        _ruleManager.RuleChanged += OnRuleChanged;
    }

    private void OnDestroy()
    {
        _ruleManager.RuleChanged -= OnRuleChanged;
    }

    private void OnRuleChanged(string ruleName, bool isActive)
    {
        CheckForRuleViolation();
    }

    private void CheckForRuleViolation()
    {
        bool swimmingRule = _ruleManager.GetRule("NoSwimming");
        bool runningRule = _ruleManager.GetRule("NoRunning");
        bool drowningRule = _ruleManager.GetRule("NoDrowning");
        bool flippingRule = _ruleManager.GetRule("NoFlips");
        bool eatingOrDrinkingRule = _ruleManager.GetRule("NoFoodOrDrink");
        bool smilingRule = _ruleManager.GetRule("NoSmiling");
        bool divingRule = _ruleManager.GetRule("NoDiving");
        bool walkingRule = _ruleManager.GetRule("NoWalking");

        if ((swimmingRule && IsSwimming) ||
            (runningRule && IsRunning) ||
            (drowningRule && IsDrowning) ||
            (flippingRule && IsFlipping) ||
            (eatingOrDrinkingRule && IsEatingOrDrinking) ||
            (smilingRule && IsSmiling) ||
            (divingRule && IsDiving) ||
            (walkingRule && IsWalking))
        {
            HasBrokenARule = true;
        }
    }
}
