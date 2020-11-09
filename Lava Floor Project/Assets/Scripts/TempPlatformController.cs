using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlatformController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 1; //Platform speed variable to easily implement a difficulty increase if decided for beta.
    //public GameObject disabler;

    private void Start()
    {
        //GameObject disabler = GameObject.FindWithTag("Platform");
        speed *= -1.0f;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 position = transform.position;

        position = new Vector2(position.x, position.y - speed * Time.deltaTime);

        transform.position = position;

        //Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            Invoke("Fall", 1f);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject, 3);
        }
    }



    private void Fall()
    {
        //disabler.GetComponent<TempPlatformController>().enabled = true;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        GetComponent<BoxCollider2D>().isTrigger = true;
    }
}
