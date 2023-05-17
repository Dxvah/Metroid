using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDControl : MonoBehaviour
{

    public TextMeshProUGUI lifesTxt;
    public TextMeshProUGUI timeTxt;
    public TextMeshProUGUI powerUpTxt;
     
     public void SetLifesTxt(int lifes)
    {
        lifesTxt.text = "Lifes:" + lifes;
    }

      public void SetTimeTxt(int time)
    {
        timeTxt.text = time.ToString();
    }
     public void SetPowerUpTxt(int howmany)
     {
        powerUpTxt.text = "PowerUp:" + howmany;
     }
}
