using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public float speed = 2; //Platform speed variable to easily implement a difficulty increase if decided for beta.
    public GameObject TestPlatform;
    private Rigidbody2D rb;

    void Start()
    {
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Death"))
        {
            Destroy(gameObject);
        }
    }

}
