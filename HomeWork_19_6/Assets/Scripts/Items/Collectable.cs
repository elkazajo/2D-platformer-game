using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public string targetTag = "Player";

    private GamePlayUiManager gamePlayUiManager;

    private void Start()
    {
        gamePlayUiManager = FindObjectOfType<GamePlayUiManager>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(targetTag))
        {
            OnCollect();
            OnDestroy();
        }
    }

    private void OnCollect()
    {
        gamePlayUiManager.currentCoinsAmount++;
    }

    private void OnDestroy()
    {
        Destroy(gameObject);
    }
}
