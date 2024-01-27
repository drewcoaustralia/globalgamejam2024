using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RuleSignManager : MonoBehaviour
{
    public TextMeshProUGUI signLeft;
    public TextMeshProUGUI signRight;

    private List<string> signTextList = new List<string>();

    public void SetText()
    {
        signLeft.text = "";
        foreach (string text in signTextList)
        {
            if (text != "") signLeft.text += "- " + text + "\n";
        }
    }

    public int AddRule(string ruleText)
    {
        signTextList.Add(ruleText);
        SetText();
        return signTextList.Count - 1;
    }

    public void RemoveRule(int index)
    {
        signTextList[index] = ""; // blank rather than remove to not break indexing
        SetText();
    }


    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
