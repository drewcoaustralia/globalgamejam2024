using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(ChildRuleStates), typeof(NavMeshAgent))]
public class ChildMovementType : MonoBehaviour
{
    [SerializeField] private float movementSpeedThreshold = 5.0f;

    private ChildRuleStates _childRuleStates;
    private NavMeshAgent _navMeshAgent;
    private float _originalSpeed;

    private void Awake()
    {
        _childRuleStates = GetComponent<ChildRuleStates>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _originalSpeed = _navMeshAgent.speed;
    }

    private void Update()
    {
        if (_navMeshAgent.velocity.magnitude > 0 && !_childRuleStates.IsSwimming)
        {
            if (_navMeshAgent.speed <= movementSpeedThreshold)
            {
                _childRuleStates.IsWalking = true;
                _childRuleStates.IsRunning = false;
            }
            else
            {
                _childRuleStates.IsWalking = false;
                _childRuleStates.IsRunning = true;
            }
        }
        else
        {
            _childRuleStates.IsWalking = false;
            _childRuleStates.IsRunning = false;
        }
    }

    public void SetNavMeshAgentSpeed(float speed)
    {
        _navMeshAgent.speed = speed;
    }

    public void ResetNavMeshAgentSpeed()
    {
        _navMeshAgent.speed = _originalSpeed;
    }
}
