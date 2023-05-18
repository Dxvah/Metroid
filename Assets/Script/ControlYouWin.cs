using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControlYouWin : MonoBehaviour
{
    public TextMeshProUGUI yourScore;
    public ControlDataGame dataGame;
    public TextMeshProUGUI nice;


    void Start()
    {
 
        dataGame = GameObject.Find("Datos Juego").GetComponent<ControlDataGame>();
        string finalMessage = "U Win!";
        string firstMessage = "Well done!";
        if (dataGame.uWin) firstMessage = "Well done!";
        if(dataGame.uWin) finalMessage += "Your Score " + dataGame.Score;
        

        yourScore.text = finalMessage;
        
    }
}
