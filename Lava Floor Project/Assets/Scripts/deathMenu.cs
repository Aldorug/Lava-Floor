using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathMenu : MonoBehaviour
{
    public GameObject menuDeath;
    void Start()
    {
        menuDeath.SetActive(false);
    }

    
    void Update()
    {
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void goToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");

    }
}
