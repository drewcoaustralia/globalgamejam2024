using System.Collections.Generic;
using UnityEngine;

// Manages AI states and transitions.
public class AIBrain : MonoBehaviour
{
    public List<AIState> States;
    public AIState CurrentState { get; private set; }

    [SerializeField] private float ActionsFrequency = 1f;
    [SerializeField] private float DecisionFrequency = 1f;

    private AIDecision[] _decisions;
    private AIAction[] _actions;
    private float _lastActionsUpdate;
    private float _lastDecisionsUpdate;

    private void Awake()
    {
        foreach (AIState state in States)
        {
            state.SetBrain(this);
        }
        _decisions = GetAttachedDecisions();
        _actions = GetAttachedActions();
    }

    private AIDecision[] GetAttachedDecisions()
    {
        AIDecision[] decisions = this.gameObject.GetComponentsInChildren<AIDecision>();
        return decisions;
    }

    private AIAction[] GetAttachedActions()
    {
        AIAction[] actions = this.gameObject.GetComponentsInChildren<AIAction>();
        return actions;
    }

    private void Start()
    {
        ResetBrain();
    }

    private void Update()
    {
        if (CurrentState == null)
            return;

        if (Time.time - _lastActionsUpdate > ActionsFrequency)
        {
            CurrentState.PerformActions();
            _lastActionsUpdate = Time.time;
        }

        if (Time.time - _lastDecisionsUpdate > DecisionFrequency)
        {
            CurrentState.EvaluateTransitions();
            _lastDecisionsUpdate = Time.time;
        }
    }

    public void TransitionToState(string newStateName)
    {
        AIState newState = FindState(newStateName);
        if (newState != null && newState != CurrentState)
        {
            CurrentState?.ExitState();
            CurrentState = newState;
            CurrentState.EnterState();
        }
    }

    private AIState FindState(string stateName)
    {
        return States.Find(state => state.StateName == stateName);
    }

    public void ResetBrain()
    {
        InitializeDecisions();
        InitializeActions();
        if (States.Count > 0)
        {
            CurrentState?.ExitState();
            CurrentState = States[0];
            CurrentState.EnterState();
        }
    }

    private void InitializeDecisions()
    {
        if (_decisions == null)
        {
            _decisions = GetAttachedDecisions();
        }
        foreach (AIDecision decision in _decisions)
        {
            decision.Initialization();
        }
    }

    private void InitializeActions()
    {
        if (_actions == null)
        {
            _actions = GetAttachedActions();
        }
        foreach (AIAction action in _actions)
        {
            action.Initialization();
        }
    }
}
