using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCounter : MonoBehaviour
{
    public GameObject playerDeath;
    public GameObject deathMenu;
    public GameObject[] hearts;
    public int lives;

    void Update()
    {
        if (lives == 0)
        {
            playerDeath.SetActive(false);
            deathMenu.SetActive(true);
            Time.timeScale = 0f;
        }

    }

    public void DamageTaken(int D)
    {
        lives -= D;
        Destroy(hearts[lives].gameObject);
    }
}
