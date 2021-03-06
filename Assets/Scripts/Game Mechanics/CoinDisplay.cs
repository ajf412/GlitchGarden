﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinDisplay : MonoBehaviour
{
    [SerializeField] int coins = 100;
    Text coinText = null;

    void Start()
    {
        coinText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        coinText.text = coins.ToString();
    }

    public bool HaveEnoughCoins(int amount)
    {
        return coins >= amount;
    }

    public void AddCoins(int amount)
    {
        coins += Mathf.CeilToInt(amount / PlayerPrefsController.GetMasterDifficulty());
        UpdateDisplay();
    }

    public void SpendCoins(int amount)
    {
        if(coins >= amount)
        {
            coins -= amount;
            UpdateDisplay();
        }
    }
}
