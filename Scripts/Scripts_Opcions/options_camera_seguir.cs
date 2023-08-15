using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class options_camera_seguir : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;
        

    // Update is called once per frame
    void Update()
    {
        // Set the camera's position to follow the player with the specified offset
        transform.position = new Vector3(player.transform.position.x + offset.x, player.transform.position.y + offset.y, offset.z);
    }
}
