using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class options_camera : MonoBehaviour
{
    public float speed = 1f;

    public GameObject player;
    public GameObject stop;
    public Vector3 offset;
    public bool ok = false;

    public Vector2 minCampPosition, maxCampPosition;

    private void Start()
    {
    }

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    private void FixedUpdate()
    {
        float posX = player.transform.position.x;  // Get the x-coordinate of the player's position
        float posY = player.transform.position.y;  // Get the y-coordinate of the player's position

        transform.Translate(speed * Time.deltaTime, 0, 0);  // Move the camera horizontally based on the speed

        // Clamp the camera's y-coordinate within the specified range
        transform.position = new Vector3(
            transform.position.x,
            Mathf.Clamp(posY, minCampPosition.y, maxCampPosition.y),
            transform.position.z);
    }
}
