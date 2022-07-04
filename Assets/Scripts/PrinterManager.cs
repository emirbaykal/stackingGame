using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrinterManager : MonoBehaviour
{
    public List<GameObject> paperList = new List<GameObject>();
    public GameObject paperPrefab;
    public Transform exitPoint;
    private bool isWorking;
    private int stackCount = 10;
    
    void Start()
    {
        StartCoroutine(printPaper());
    }

    public void removeLast()
    {
        if (paperList.Count > 0)
        {
            Destroy(paperList[paperList.Count - 1]);
            paperList.RemoveAt(paperList.Count -  1);
        }
    }
    
    IEnumerator printPaper()
    {
        while (true)
        {
            float paperCount = paperList.Count;
            int rowCount = (int) paperCount / 10;
            if (isWorking)
            {
                GameObject temp = Instantiate(paperPrefab);
                temp.transform.position = new Vector3(exitPoint.position.x+((float)rowCount/2),(paperCount%stackCount)/10, exitPoint.position.z);
                paperList.Add(temp);
                if (paperList.Count >=30)
                {
                    isWorking = false;
                }
            }
            else if (paperList.Count<30)
            {
                isWorking = true;
            }
            yield return new WaitForSeconds(1f);
        }
        
    }
}
