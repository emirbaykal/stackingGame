using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyArea : MonoBehaviour
{
    public Image progressImage;
    public GameObject DeskGameObject, buyGameObject, buyArea;
    public float cost, currentMoney,progress;
    
    public void Buy(int goldAmount)
    {
        currentMoney += goldAmount;
        progress = currentMoney / cost;
        progressImage.fillAmount = progress;
        if (progress >=1)
        {
            buyGameObject.SetActive(false);
            DeskGameObject.SetActive(true);
            enabled = false;
            if (cost == currentMoney)
            {
                buyArea.tag = "Untagged";
            }
        }

    }
}
