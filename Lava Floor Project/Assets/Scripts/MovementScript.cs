using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementScript : MonoBehaviour
{
    public float jumpHeight;
    public float movementSpeed;

    private Rigidbody2D playerBody;

    private void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
    }

    // If we were to make the movement for pc along with changing private move and jump to public
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();

        Move(0);

        if (Input.GetKey(KeyCode.LeftArrow))
            Move(-1);

        if (Input.GetKey(KeyCode.RightArrow))
            Move(1);
    }

    public void Move(int xDirection)
    {
        Vector2 direction = new Vector2(xDirection, 0) * movementSpeed * Time.deltaTime;
        playerBody.velocity += direction;
    }

    public void Jump()
    {
        // Vector2.up * jumpHeight is an other way to write it
        // playerBody.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
        playerBody.velocity = new Vector2(playerBody.velocity.x, jumpHeight); // Forcemode.impulse applies the changes from multiplying jump height on the player object instantly, as it is usually applied gradually over time
        // Will add check requirement for if the player is not in the air before letting you jump
    }
}