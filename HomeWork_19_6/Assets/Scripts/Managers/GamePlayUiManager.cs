using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GamePlayUiManager : MonoBehaviour
{
    [SerializeField] private TMP_Text coinsCollectedTotal;
    [SerializeField] private TMP_Text hpTotal;

    public int currentCoinsAmount;
    public float currentHealth;
    Health health;

    private void Start()
    {
        health = GameObject.Find("Player").GetComponent<Health>();
    }

    void Update()
    {
        coinsCollectedTotal.text = $"Coins: {currentCoinsAmount}";
        hpTotal.text = $"HP: {health.currentHealth}";
    }
}
