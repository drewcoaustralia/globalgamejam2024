using UnityEngine;

public class RuleToggleGUI : MonoBehaviour
{
    private RuleManager ruleManager;
    private bool noSwimming;
    private bool noRunning;
    private bool noDrowning;

    private void Start()
    {
        ruleManager = RuleManager.Instance;
        noSwimming = ruleManager.GetRule("NoSwimming");
        noRunning = ruleManager.GetRule("NoRunning");
        noDrowning = ruleManager.GetRule("NoDrowning");
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(20, 20, 200, 50), "Toggle NoSwimming"))
        {
            noSwimming = !noSwimming;
            ruleManager.SetRule("NoSwimming", noSwimming);
        }

        GUI.Label(new Rect(230, 20, 200, 50), "NoSwimming is " + (noSwimming ? "ON" : "OFF"));

        if (GUI.Button(new Rect(20, 80, 200, 50), "Toggle NoRunning"))
        {
            noRunning = !noRunning;
            ruleManager.SetRule("NoRunning", noRunning);
        }

        GUI.Label(new Rect(230, 80, 200, 50), "NoRunning is " + (noRunning ? "ON" : "OFF"));

        if (GUI.Button(new Rect(20, 140, 200, 50), "Toggle NoDrowning"))
        {
            noDrowning = !noDrowning;
            ruleManager.SetRule("NoDrowning", noDrowning);
        }

        GUI.Label(new Rect(230, 140, 200, 50), "NoDrowning is " + (noDrowning ? "ON" : "OFF"));
    }
}
