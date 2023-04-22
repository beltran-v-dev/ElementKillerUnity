using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_moviment : MonoBehaviour
{
    public player_control controller;

    private float horizontalMove = 0f;

    public float runSpeed = 40f;

    private bool jump = false;

    private int numJump = 0;

    private void Start()
    {
    }

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    //Moviemnt del personatge en fixedUpdate
    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);

        jump = false;
    }
}