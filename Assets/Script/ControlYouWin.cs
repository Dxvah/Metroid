using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControlYouWin : MonoBehaviour
{
    public TextMeshProUGUI yourScore;
    private ControlDataGame dataGame;


    void Start()
    {
        dataGame = GameObject.Find("Datos Juego").GetComponent<ControlDataGame>();
        string finalMessage = (dataGame.uWin) "U Win!";
        if(dataGame.uWin) finalMessage += "Your Score" + dataGame.Score;

        yourScore.text = finalMessage;
        
    }
}
