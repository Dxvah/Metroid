using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    
    public void OnPlayButton()
    {
        SceneManager.LoadScene("Nivel 1");
    }
     public void OnExitButton()
    {
        Application.Quit();
    }

}
