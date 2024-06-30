using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuButtonScript : MonoBehaviour
{
    public GameObject settingsMenu;    public GameObject mainMenu;


    public void Commence()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("TerrainGenTest");
    }

    public void OpenOptions()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }
    public void CloseOptions()
    {
        mainMenu.SetActive(true);
    }


    public void Quit()
    {
        Application.Quit();       
    }



 
}
