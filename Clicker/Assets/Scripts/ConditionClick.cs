using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ConditionClick : Condition
{
    private void OnMouseDown()
    {
        ExecuteAllActions(null);
    }
}