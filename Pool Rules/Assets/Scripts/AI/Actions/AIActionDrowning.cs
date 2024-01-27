using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIActionDrowning : AIAction
{
    [SerializeField] private Child child;

    private void Awake()
    {
        if (child == null) Debug.LogWarning("child is null");
    }

    public override void PerformAction()
    {
        child.IsDrowning = true;
    }
}
