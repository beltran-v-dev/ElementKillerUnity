using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_moviment : MonoBehaviour
{
    public player_control controller;  // Reference to the player control script.

    private float horizontalMove = 0f;  // Stores the horizontal movement input value.

    public float runSpeed = 40f;  // The speed at which the player character moves.

    private bool jump = false;  // Flag to indicate if the player wants to jump.

    private int numJump = 0;  // Number of times the player has jumped.

    private void Start()
    {
        // Initialization code that runs when the script starts.
    }

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;  // Get the horizontal input for movement.

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;  // Detect if the player pressed the jump button.
        }
    }

    // Movement of the character in FixedUpdate.
    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);  // Move the player using the controller script.

        jump = false;  // Reset the jump flag.
    }
}
