using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public float currentMoney;
    
    public void EarnMoney(float moneyValue)
    {
        currentMoney += moneyValue;
    }

    public void SpendMoney(float moneyValue)
    {
        currentMoney -= moneyValue;
    }
}
