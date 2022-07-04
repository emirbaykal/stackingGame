using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    public delegate void onCollectArea();
    public static event onCollectArea onPaperCollect;
    public static PrinterManager printerManager;

    public delegate void OnDeskArea();
    public static event OnDeskArea OnPaperGive;
    public static WorkerManager workerManager;

    public delegate void OnMoneyArea();
    public static event OnMoneyArea onMoneyCollected;

    public delegate void BuyDeskArea();
    public static event OnDeskArea onBuyingDesk;
    public static BuyArea areaToBuy;

    private bool isCollecting,isGiving;
    void Start()
    {
        StartCoroutine(collectEnum());
    }

    IEnumerator collectEnum()
    {
        while (true)
        {
            if (isCollecting)
            {
                onPaperCollect();
            }

            if (isGiving)
            {
                OnPaperGive();
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("BuyArea"))
        {
            onBuyingDesk();
            areaToBuy = other.gameObject.GetComponent<BuyArea>();
        }
        if (other.gameObject.CompareTag("CollectArea"))
        {
            isCollecting = true;
            printerManager = other.gameObject.GetComponent<PrinterManager>();
        }
        if (other.gameObject.CompareTag("WorkArea"))
        {
            isGiving = true;
            workerManager = other.gameObject.GetComponent<WorkerManager>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Money"))
        {
            onMoneyCollected();
            Destroy(other.gameObject);
            removeLast();
        }
    }
    
    public void removeLast()
    {
        if (workerManager.moneyList.Count > 0)
        {
            Destroy(workerManager.moneyList[workerManager.moneyList.Count - 1]);
            workerManager.moneyList.RemoveAt(workerManager.moneyList.Count -  1);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("CollectArea"))
        {
            isCollecting = false;
            printerManager = null;
        }
        if (other.gameObject.CompareTag("WorkArea"))
        {
            isGiving = false;
            workerManager = null;
        }
        if (other.gameObject.CompareTag("BuyArea"))
        {
            
            areaToBuy = null;
        }
    }
}
