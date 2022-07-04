using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectManager : MonoBehaviour
{
    public List<GameObject> paperList = new List<GameObject>();
    public GameObject paperPrefab;
    public Transform collectPoint;

    private int paperLimit = 10;

    private void OnEnable()
    {
        TriggerManager.onPaperCollect += getPaper;
        TriggerManager.OnPaperGive += givePaper;
    }

    private void OnDisable()
    {
        TriggerManager.onPaperCollect -= getPaper;
        TriggerManager.OnPaperGive -= givePaper;

    }

    void getPaper()
    {
        if (paperList.Count<=paperLimit)
        {
            GameObject temp = Instantiate(paperPrefab,collectPoint);
            temp.transform.position = new Vector3(collectPoint.position.x,0.5f+ 
                ((float) paperList.Count / 20),
                collectPoint.position.z);
            paperList.Add(temp);
            if (TriggerManager.printerManager!=null)
            {
                TriggerManager.printerManager.removeLast();
            }
        }
    }

    public void givePaper()
    {
        if (paperList.Count> 0)
        {
            TriggerManager.workerManager.GetPaper();
            removeLast();
        }
    }
    public void removeLast()
    {
        if (paperList.Count > 0)
        {
            Destroy(paperList[paperList.Count - 1]);
            paperList.RemoveAt(paperList.Count -  1);
        }
    }
}
