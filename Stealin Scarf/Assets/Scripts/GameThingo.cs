using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameThingo : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject GUI;
    public GameObject endGameUI;

    bool gameEnded = false;

    public float timer;

    public TMP_Text scoreDisplay;

    ScoreManager scoreMan;

    private void Start()
    {
        scoreMan = GameObject.Find("ScoreMan").GetComponent<ScoreManager>();
    }

    private void Update()
    {

        timer -= Time.deltaTime;
        if (timer <= 0 && !gameEnded)
        {
            EndGame(); //return ;
            gameEnded = true;
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
                
            }
            else
            {
                Pause();
                
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        GUI.SetActive(true);
        Time.timeScale = 1f;
        gameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        GUI.SetActive(false);
        Time.timeScale = 0f;
        gameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void EndGame()
    {
        //end ui with "wealth redistributed" then spot for the value. button to go to main menu or quit game. 
        //disable gui and enable end ui, set value text to value number from zoes script.

        endGameUI.SetActive(true);
        GUI.SetActive(false);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        scoreDisplay.text =  "$ " + scoreMan.Score().ToString();
    }
}
