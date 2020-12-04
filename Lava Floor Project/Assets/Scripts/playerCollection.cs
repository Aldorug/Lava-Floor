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
    public LifeCounter Damage;

    public float scoreValue;
    public float timeLeft;
    public Text scoreText;

    //gamePlaySlowTime DataField use for Slow Affect
    public float gamePlaySlow;
    //delayTime field for how long Slow Affect will
    public float delayTime=0.2f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timeLeft = 3.0f;
        scoreText.text = "Score: " + scoreValue.ToString();
    }

    //Fixed Update()
    //{
    //   timeLeft -= Time.deltaTime;
    //
    //    if(timeLeft <= 1) 
    //       {
    //        Physics.gravity = new Vector3(0, -20, 0);
    //       timeLeft = 0;
    //        }
    //}

        private void OnTriggerEnter2D(Collider2D other)
    {
        //sets player gravity on trigger overlap
        if (other.gameObject.CompareTag("Gravity"))
        {
            other.gameObject.SetActive(false);
            rb.gravityScale *= -1.0f;
        }

        //sets scoreValue for UI
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            scoreValue += 1;
            scoreText.text = "Score: " + scoreValue.ToString();
        }

        if(other.gameObject.CompareTag("GravityPickup"))
        {
            other.gameObject.SetActive(false);

            //Start GamePlaySlow Coroutine
            StartCoroutine(GamePlaySlow());
        }

        //Kills player and brings up death menu
        if (other.gameObject.CompareTag("Death"))
        {
            playerDeath.SetActive(false);
            deathMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    //Coroutine for Slow Motion Affect
    IEnumerator GamePlaySlow()
    {
        Time.timeScale = gamePlaySlow * 2;
        yield return new WaitForSeconds(delayTime);
        Time.timeScale = 1;
    }

}
