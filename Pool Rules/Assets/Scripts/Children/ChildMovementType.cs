using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(ChildRuleStates), typeof(NavMeshAgent))]
public class ChildMovementType : MonoBehaviour
{
    [SerializeField] private float movementSpeedThreshold = 5.0f;
    private ChildAnimationController _animationController;

    private ChildRuleStates _childRuleStates;
    private NavMeshAgent _navMeshAgent;
    private float _originalSpeed;
    private float speedLastFrame = 0f;

    private void Awake()
    {
        _animationController = GetComponent<ChildAnimationController>();
        _childRuleStates = GetComponent<ChildRuleStates>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _originalSpeed = _navMeshAgent.speed;
    }

    private void Update()
    {
        // unsure why we need swimming here
        if (_navMeshAgent.velocity.magnitude > 0f && speedLastFrame == 0f && !_childRuleStates.IsSwimming)
        {
            if (_navMeshAgent.speed <= movementSpeedThreshold)
            {
                _animationController.SetAnimation("walking");
                _childRuleStates.IsWalking = true;
                _childRuleStates.IsRunning = false;
            }
            else
            {
                _animationController.SetAnimation("running");
                _childRuleStates.IsWalking = false;
                _childRuleStates.IsRunning = true;
            }
        }
        else if (_navMeshAgent.velocity.magnitude == 0f && speedLastFrame > 0f && !_childRuleStates.IsSwimming)
        {
            _animationController.SetIdling();
            _childRuleStates.IsWalking = false;
            _childRuleStates.IsRunning = false;
        }

        speedLastFrame = _navMeshAgent.velocity.magnitude;
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
