using System;
using UnityEngine;

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