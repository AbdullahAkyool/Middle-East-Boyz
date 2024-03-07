using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager Instance;
    
    public float currentMoneyCount;
    public TMP_Text moneyCountText;

    private void Awake()
    {
        Instance = this;
        
        moneyCountText.text = currentMoneyCount.ToString();

        ActionManager.OnWeaponPurchase += SpendMoney;
    }

    public void EarnMoney(float moneyValue)
    {
        currentMoneyCount += moneyValue;
        moneyCountText.text = currentMoneyCount.ToString();
    }

    private void SpendMoney(float moneyValue)
    {
        if(currentMoneyCount - moneyValue < 0 ) return;
        currentMoneyCount -= moneyValue;
        moneyCountText.text = currentMoneyCount.ToString();
    }
}
