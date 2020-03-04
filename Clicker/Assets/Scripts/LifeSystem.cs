using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSystem : Action
{
    [Header("Life counter")] [SerializeField]
    private int life = 1;

    [Header("Actions on death")] public Action[] actionsOnHit;

    [Header("Actions on death")] public Action[] actionsOnDeath;

    private void Start()
    {
        var script = GetComponent<Action>();
        actionsOnDeath = new[] {script};
    }

    public override bool ExecuteAction(GameObject otherObject)
    {
        life--;
        foreach (var variable in actionsOnHit)
        {
            variable.ExecuteAction(otherObject);
        }

        if (life < 1)
            foreach (var variable in actionsOnDeath)
            {
                variable.ExecuteAction(otherObject);
            }

        return true;
    }
}