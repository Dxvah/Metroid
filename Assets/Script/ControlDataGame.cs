using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDataGame : MonoBehaviour
{
    
    public int score;
    public bool uWin;

    public int Score { get => score; set => score = value; }

     public bool UWin { get => uWin; set => uWin = value; }

    private void Awake()
    {
        int numInstance = FindObjectsOfType<ControlDataGame>().Length;

        if(numInstance != 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

}
