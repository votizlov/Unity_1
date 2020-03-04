using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionClick : MonoBehaviour
{
    public Action[] actions;
    [SerializeField]
    private int _life;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        _life--;
        //this.GetComponent<Rigidbody2D>().rotation += 10;
        Debug.Log("clicked");
        if (_life == 0)
        {
            foreach (var action in actions)
            {
                action.ExecuteAction(null);
            }
        }
    }


}
