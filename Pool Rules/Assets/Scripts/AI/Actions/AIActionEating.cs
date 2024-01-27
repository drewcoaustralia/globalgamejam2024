using System.Collections;
using UnityEngine;

public class AIActionEating : AIAction
{
    [SerializeField] private ChildRuleStates childRuleStates;
    [SerializeField] private AIDecisionTriggered aiDecisionTriggered;
    [SerializeField] private float waitTime = 10.0f;
    private bool isEatingCoroutineRunning = false;

    private void Awake()
    {
        if (childRuleStates == null) childRuleStates = GetComponentInParent<ChildRuleStates>();
        if (childRuleStates == null) Debug.LogWarning("childRuleStates is null");
        if (aiDecisionTriggered == null) Debug.LogWarning("aiDecisionTriggered is null");
    }

    public override void PerformAction()
    {
        if (!isEatingCoroutineRunning)
        {
            StartCoroutine(EatingCoroutine());
        }
    }

    private IEnumerator EatingCoroutine()
    {
        isEatingCoroutineRunning = true;
        yield return new WaitForSeconds(waitTime);
        Debug.LogWarning("EatingCoroutine: Waited for " + waitTime + " seconds. Add animations and SFX here.");
        isEatingCoroutineRunning = false;
        TransitionOut();
    }

    private void TransitionOut()
    {
        aiDecisionTriggered.TransitionOut();
    }
}
