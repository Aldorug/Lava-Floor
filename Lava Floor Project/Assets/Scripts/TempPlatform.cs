using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlatform : MonoBehaviour
{
    Rigidbody2D rb;
    public float standingTime;
    public float destroyTime;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Invoke("DropPlatform", 3f);
            Destroy(gameObject, 5f);
        }
    }

    void DropPlatform()
    {
        rb.isKinematic = false;
    }
}
