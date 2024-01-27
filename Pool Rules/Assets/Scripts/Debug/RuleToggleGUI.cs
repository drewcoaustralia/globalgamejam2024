using UnityEngine;

public class RuleToggleGUI : MonoBehaviour
{
    [SerializeField]
    private bool isGUIToggled = true;

    private RuleManager _ruleManager;
    private bool[] rules;
    private string[] ruleNames;

    private int buttonsPerColumn = 10;
    private float buttonWidth = 200;
    private float buttonHeight = 50;
    private float buttonSpacing = 10;
    private Vector2 scrollPosition = Vector2.zero;

    private void Start()
    {
        _ruleManager = RuleManager.Instance;
        InitializeRules();
    }

    private void InitializeRules()
    {
        ruleNames = new string[]
        {
            "NoSwimming", "NoRunning", "NoDrowning", "NoFlips", "NoFoodOrDrink",
            "NoSmiling", "NoDiving", "NoWalking", "NoPhones", "NoFlipPhone",
            "NoFlipFlops", "NoFerret", "NoTrenchcoat", "NoPrimeMinister", "NoSwearing",
            "NoBackstroking", "NoScubaGear", "NoAlien", "NoGinger", "NoSmoking",
            "NoVaping", "NoBeard", "NoStreaking", "NoDaydreaming", "NoNoodle",
            "NoParking", "NoTowel", "NoContemplatingTheMeaningOfLife", "NoUrinating",
            "NoCooking", "NoOverthrowingGovernment", "NoBoombox", "NoBeatboxing",
            "NoBoxing", "NoToaster", "NoFishing", "NoLaughing", "NoLittering",
            "NoFighting", "NoBike", "NoScooter", "NoSkateboard", "NoBallGame"
        };

        int numberOfRules = ruleNames.Length;
        rules = new bool[numberOfRules];

        for (int i = 0; i < numberOfRules; i++)
        {
            rules[i] = _ruleManager.GetRule(ruleNames[i]);
        }
    }

    private void OnGUI()
    {
        if (!isGUIToggled) return;

        int numberOfColumns = Mathf.CeilToInt((float)rules.Length / buttonsPerColumn);
        float totalWidth = buttonWidth + buttonSpacing;
        float totalHeight = (buttonHeight + buttonSpacing) * numberOfColumns;

        scrollPosition = GUI.BeginScrollView(new Rect(20, 20, Screen.width - 40, Screen.height - 40), scrollPosition, new Rect(0, 0, totalWidth, totalHeight));

        int buttonIndex = 0;

        for (int col = 0; col < numberOfColumns; col++)
        {
            for (int row = 0; row < buttonsPerColumn; row++)
            {
                if (buttonIndex >= rules.Length)
                {
                    break;
                }

                float x = col * (buttonWidth + buttonSpacing);
                float y = row * (buttonHeight + buttonSpacing);

                rules[buttonIndex] = ToggleRule(ruleNames[buttonIndex], rules[buttonIndex], new Vector2(x, y));
                buttonIndex++;
            }
        }

        GUI.EndScrollView();
    }

    private bool ToggleRule(string ruleName, bool ruleValue, Vector2 position)
    {
        if (GUI.Button(new Rect(position.x, position.y, buttonWidth, buttonHeight), "Toggle " + ruleName))
        {
            ruleValue = !ruleValue;
            _ruleManager.SetRule(ruleName, ruleValue);
        }

        GUI.Label(new Rect(position.x + buttonWidth + buttonSpacing, position.y, buttonWidth, buttonHeight), ruleName + " is " + (ruleValue ? "ON" : "OFF"));
        return ruleValue;
    }
}
