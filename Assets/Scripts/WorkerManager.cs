using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerManager : MonoBehaviour
{
    public List<GameObject> paperList = new List<GameObject>();
    public List<GameObject> moneyList = new List<GameObject>();

    public Transform paperPoint,moneyDropPoint;
    public GameObject paperPrefab,moneyPrefab;

    private void Start()
    {
        StartCoroutine(GenerateMoney());
    }

    IEnumerator GenerateMoney()
    {
        while (true)
        {
            if (paperList.Count>0)
            {
                GameObject temp = Instantiate(moneyPrefab);
                temp.transform.position = new Vector3(moneyDropPoint.position.x,((float)moneyList.Count/10), moneyDropPoint.position.z);
                moneyList.Add(temp);
                removeLast();
            }
            yield return new WaitForSeconds(2f);
        }
    }

    public void GetPaper()
    {
        GameObject temp = Instantiate(paperPrefab);
        temp.transform.position = new Vector3(paperPoint.position.x,0.8f+((float)paperList.Count/10), paperPoint.position.z);
        paperList.Add(temp);
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
