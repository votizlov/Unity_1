using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableAction : Action
{
    public override bool ExecuteAction(GameObject otherObject)
    {
        gameObject.SetActive(true);
        return true;
    }
}