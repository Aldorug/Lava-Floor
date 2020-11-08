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

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
             Invoke("Fall", 1f);
        }

        if (col.gameObject.CompareTag("Death"))
        {
            Destroy(gameObject);
        }

    }

    private void Fall()
    {
        //disabler.GetComponent<TempPlatformController>().enabled = true;
        rb.isKinematic = false;
    }
}
