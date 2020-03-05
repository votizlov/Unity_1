using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitAction : Action
{
    public float secondsShowing;

    public override bool ExecuteAction(GameObject otherObject)
    {
        if (otherObject != null)
        {
            
            GetComponent<Renderer>().enabled = true;
            this.transform.position = otherObject.transform.position;
            Invoke(nameof(Hide), secondsShowing);
        }

        return true;
    }

    private void Hide()
    {
        GetComponent<Renderer>().enabled = false;
    }
}