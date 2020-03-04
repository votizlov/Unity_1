using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ConditionClick : MonoBehaviour
{
    public Action[] actions;

    private void OnMouseDown()
    {
        foreach (var action in actions)
        {
            action.ExecuteAction(null);
        }
    }
}