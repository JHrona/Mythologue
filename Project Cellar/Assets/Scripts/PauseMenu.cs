using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isPaused;

    // Start
    public void Start()
    {
        
        pauseMenu.SetActive(false);
    }

    // Nastavení
        public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }


    // Vypnutní Nastavení
        public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    // Vypnutní Nastavení
        public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }


    // Exit
    public void Quit()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }


        public void LEVEL1()
    {
        Time.timeScale = 1f;
       SceneManager.LoadScene(1); 
    }

        
        public void LEVEL2()
    {
       Time.timeScale = 1f; 
       SceneManager.LoadScene(2); 
    }

        public void GoToMainMenu()
    {
        Time.timeScale = 1f;
       SceneManager.LoadScene(0); 
    }
}

// if(!PauseMenu.isPaused) {}
