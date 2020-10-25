using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public GameObject menuPause;
    void Start()
    {
        menuPause.SetActive(false);
    }

    
    void Update()
    {
        
    }

    public void PauseGame()
    {
        menuPause.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        menuPause.SetActive(false);
        Time.timeScale = 1f;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
