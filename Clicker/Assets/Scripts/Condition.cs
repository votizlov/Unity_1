using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class Condition : MonoBehaviour
{
    public Action[] Actions = new Action[0];
    //filter to find objects
    public string filterTag;

    public void ExecuteAllActions(GameObject dataObject)
    {
        foreach (var ga in Actions.Where(ga => ga != null))
            ga.ExecuteAction(dataObject);
    }
}
