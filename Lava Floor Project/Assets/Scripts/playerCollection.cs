using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class playerCollection : MonoBehaviour
{
    private Rigidbody2D rb;

    public GameObject playerDeath;
    public GameObject deathMenu;

    public float scoreValue;
    public Text scoreText;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        scoreText.text = "Score: " + scoreValue.ToString();
    }

   
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        //sets player gravity on trigger overlap
        if (other.gameObject.CompareTag("Gravity"))
        {
            other.gameObject.SetActive(false);
            rb.gravityScale *= -1;
        }

        //sets scoreValue for UI
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            scoreValue += 1;
            scoreText.text = "Score: " + scoreValue.ToString();

        }

        //Kills player and brings up death menu
        if (other.gameObject.CompareTag("Death"))
        {
            playerDeath.SetActive(false);
            deathMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    

}
