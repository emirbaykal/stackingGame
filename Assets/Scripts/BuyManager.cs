using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyManager : MonoBehaviour
{
    public Text moneyText;
    public int moneyCount = 0;
    private void OnEnable()
    {
        TriggerManager.onMoneyCollected += IncreaseMoney;
        TriggerManager.onBuyingDesk += BuyArea;
    }

    private void OnDisable()
    {
        TriggerManager.onMoneyCollected -= IncreaseMoney;
        TriggerManager.onBuyingDesk -= BuyArea;
    }

    void BuyArea()
    {
        if (TriggerManager.areaToBuy !=null)
        {
            if (moneyCount>=1)
            {
                TriggerManager.areaToBuy.Buy(1);
                moneyCount -= 1;
            }
        }
    }

    void IncreaseMoney()
    {
        moneyCount += 50;
    }

    private void Update()
    {
        moneyText.text = "$" + moneyCount;
    }
}
