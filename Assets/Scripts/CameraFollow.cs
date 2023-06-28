using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * CameraFollow is a short script that is meant to have the camera follow the player.
 * originally it hard followed the player including the x axis. however It hurt to watch so i changedf it to only follow the y axis of the player.
 */
public class CameraFollow : MonoBehaviour
{
    public Transform target; // target is the object this script will target in this case it is the player.

    void LateUpdate()//put in LateUpdate because it makes the movement adn following look a lot smoother.
    {
        Vector3 desiredPosition = new Vector3(transform.position.x, target.position.y, transform.position.z);
        transform.position = desiredPosition;// basically the transform is equal to the y position of the target meanign it will always follow the player.
    }
}
