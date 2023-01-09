using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public string targetTag = "Player";

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(targetTag))
        {
            OnCollect();
            OnDestroy();
        }
    }

    protected virtual void OnCollect()
    {
        // add necessary logic in child class 
    }

    protected void OnDestroy()
    {
        Destroy(gameObject);
    }
}
