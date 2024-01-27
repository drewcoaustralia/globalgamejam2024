using UnityEngine;

public class RuleToggleGUI : MonoBehaviour
{
    private RuleManager ruleManager;
    private bool noSwimming;
    private bool noRunning;
    private bool noDrowning;
    private bool noFlips;
    private bool noFoodOrDrink;
    private bool noSmiling;
    private bool noDiving;
    private bool noWalking;

    private void Start()
    {
        ruleManager = RuleManager.Instance;
        noSwimming = ruleManager.GetRule("NoSwimming");
        noRunning = ruleManager.GetRule("NoRunning");
        noDrowning = ruleManager.GetRule("NoDrowning");
        noFlips = ruleManager.GetRule("NoFlips");
        noFoodOrDrink = ruleManager.GetRule("NoFoodOrDrink");
        noSmiling = ruleManager.GetRule("NoSmiling");
        noDiving = ruleManager.GetRule("NoDiving");
        noWalking = ruleManager.GetRule("NoWalking");
    }

    private void OnGUI()
    {
        noSwimming = ToggleRule("NoSwimming", noSwimming, new Vector2(20, 20));
        noRunning = ToggleRule("NoRunning", noRunning, new Vector2(20, 80));
        noDrowning = ToggleRule("NoDrowning", noDrowning, new Vector2(20, 140));
        noFlips = ToggleRule("NoFlips", noFlips, new Vector2(20, 200));
        noFoodOrDrink = ToggleRule("NoFoodOrDrink", noFoodOrDrink, new Vector2(20, 260));
        noSmiling = ToggleRule("NoSmiling", noSmiling, new Vector2(20, 320));
        noDiving = ToggleRule("NoDiving", noDiving, new Vector2(20, 380));
        noWalking = ToggleRule("NoWalking", noWalking, new Vector2(20, 440));
    }

    private bool ToggleRule(string ruleName, bool ruleValue, Vector2 position)
    {
        if (GUI.Button(new Rect(position.x, position.y, 200, 50), "Toggle " + ruleName))
        {
            ruleValue = !ruleValue;
            ruleManager.SetRule(ruleName, ruleValue);
        }

        GUI.Label(new Rect(position.x + 210, position.y, 200, 50), ruleName + " is " + (ruleValue ? "ON" : "OFF"));
        return ruleValue;
    }
}
