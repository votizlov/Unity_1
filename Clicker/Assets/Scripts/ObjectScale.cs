using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScale : MonoBehaviour
{
    public float k = 1.1f;

    private void Update()
    {
        gameObject.transform.localScale *= k;
    }
}