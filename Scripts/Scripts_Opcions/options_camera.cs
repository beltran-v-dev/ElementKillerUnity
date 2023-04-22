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

    //private void seguirPlayer()
    //{
    //    transform.position = new Vector3(player.transform.position.x + offset.x, player.transform.position.y + offset.y, offset.z);
    //}

    private void FixedUpdate()
    {
        float posX = player.transform.position.y;
        float posY = player.transform.position.y;

        transform.Translate(speed * Time.deltaTime, 0, 0);

        transform.position = new Vector3(
            transform.position.x,
            Mathf.Clamp(posY, minCampPosition.y, maxCampPosition.y),
            transform.position.z);
    }
}