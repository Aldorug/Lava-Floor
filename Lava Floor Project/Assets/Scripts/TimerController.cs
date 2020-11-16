using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour
{
    public float countdownTime;
    public Text countdownText;
    public GameObject winScreen;

    private void Start()
    {
        winScreen.SetActive(false);
    }

    private void Update()
    {
        countdownTime -= 1 * Time.deltaTime;
        countdownText.text = "Time left: " + countdownTime.ToString("F0");

        if(countdownTime <= 0)
        {
            Time.timeScale = 0f;
            winScreen.SetActive(true);

        }
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
