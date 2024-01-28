using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildAudioBridge : MonoBehaviour
{
    [SerializeField] private AudioClip drowningAudioClip;
    
    private AudioManager audioManager;
    private ChildRuleStates ruleStates;

    private void Awake()
    {
        ruleStates = GetComponent<ChildRuleStates>();
        if (ruleStates == null) Debug.LogWarning("No ChildRuleStates attached");
    }

    private void Start()
    {
        audioManager = AudioManager.Instance;
    }
}
