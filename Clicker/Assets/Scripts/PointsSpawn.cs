using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PointsSpawn : Action
{
    public GameObject point;

    public override bool ExecuteAction(GameObject otherObject)
    {
        if (otherObject != null)
        {
            GameObject newObject = Instantiate<GameObject>(point, new Vector3(2, 2, 2), Quaternion.identity);
        }
        else
            throw new NullReferenceException();

        return true;
    }
}