﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementScript : MonoBehaviour
{
    [Header("Movement")]
    public float jumpHeight;
    public float acceleration;
    public float deceleration;
    public float maxSpeed;

    private Rigidbody2D playerBody;
    private float curHorSpeed;
    private float horzDir;

    private void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
    }

    // If we were to make the movement for pc along with changing private move and jump to public. This function is for testing movement/jumping and can be deleted after polishing.
    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //        Jump();

    //    horzDir = Input.GetAxisRaw("Horizontal");
    //}

    public void Move(int xDirection)
    {
        horzDir = xDirection;
    }

    public void Jump()
    {
        // Vector2.up * jumpHeight is an other way to write it
        // playerBody.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
        playerBody.velocity = new Vector2(playerBody.velocity.x, jumpHeight); // Forcemode.impulse applies the changes from multiplying jump height on the player object instantly, as it is usually applied gradually over time
        // Will add check requirement for if the player is not in the air before letting you jump
    }

    private void FixedUpdate()
    {
        if (horzDir != 0)
        {
            curHorSpeed += acceleration * horzDir;

            //Mathf.Clamp is shorthand for this:
            //if (curHorSpeed < -maxSpeed)
            //    curHorSpeed = -maxSpeed;
            //else if (curHorSpeed > maxSpeed)
            //    curHorSpeed = maxSpeed;

            curHorSpeed = Mathf.Clamp(curHorSpeed, -maxSpeed, maxSpeed);
        }
        else
        {
            //Mathf.Max is shorthand for this:
            //curHorSpeed -= deceleration;
            //if (curHorSpeed < 0)
            //    curHorSpeed = 0;

            curHorSpeed = Mathf.Max(0, curHorSpeed - deceleration);
        }

        playerBody.velocity = new Vector2(curHorSpeed, playerBody.velocity.y);
    }
}