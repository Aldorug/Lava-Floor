using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollection : MonoBehaviour
{
    private Rigidbody2D rb;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

   
   //sets player gravity on trigger overlap 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Gravity"))
        {
            other.gameObject.SetActive(false);
            rb.gravityScale *= -1;
        }
    }

    

}
