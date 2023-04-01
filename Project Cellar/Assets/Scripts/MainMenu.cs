using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsPanel;
    // Start
    public void StartGame()
    {
       SceneManager.LoadScene(1); 
    }


    // Nastavení
        public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    // Vypnutní Nastavení
        public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }


    // Exit
    public void ExitGame()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
