using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class AIState
{
    public string StateName;
    public List<AIAction> Actions;
    public List<AITransition> Transitions; 

    private AIBrain _brain;

    public void SetBrain(AIBrain brain)
    {
        _brain = brain;
    }

    public void EnterState()
    {
        foreach (AIAction action in Actions)
        {
            action.OnEnterState();
        }
        foreach (AITransition transition in Transitions)
        {
            transition.Decision?.OnEnterState();
        }
    }

    public void ExitState()
    {
        foreach (AIAction action in Actions)
        {
            action.OnExitState();
        }
        foreach (AITransition transition in Transitions)
        {
            transition.Decision?.OnExitState();
        }
    }

    public void PerformActions()
    {
        foreach (AIAction action in Actions)
        {
            action?.PerformAction();
        }
    }

    public void EvaluateTransitions()
    {
        foreach (AITransition transition in Transitions)
        {
            bool decisionResult = transition.Decision?.Decide() ?? false;
            string nextState = decisionResult ? transition.TrueState : transition.FalseState;

            if (!string.IsNullOrEmpty(nextState))
            {
                _brain.TransitionToState(nextState);
                break;
            }
        }
    }
}
