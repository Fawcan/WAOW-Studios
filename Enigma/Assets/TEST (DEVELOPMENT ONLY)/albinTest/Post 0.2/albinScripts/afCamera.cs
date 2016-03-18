using UnityEngine;
using System.Collections;

/*
**** WAOW STUDIOS **** 
     [DISCLAIMER]

    This script makes it so the camera follows the player.
    Put this script in the Main Camera and the Player as target.

    Notes:

*** THIS SCRIPT IS TO BE HANDELD BY ASSIGNED RESOURCE UNTIL OTHERWISE AND NOT TO BE EDITED WITHOUT PERMISSION ***
*/

public class afCamera : MonoBehaviour
{
    public Transform target;            // The position that that camera will be following.
    public float smoothing = 60f;        // The speed with which the camera will be following.

    Vector3 offset;                     // The initial offset from the target.


    void Start()
    {
        // Calculate the initial offset.
        offset = transform.position - target.position;
    }


    void FixedUpdate()
    {
        // Create a postion the camera is aiming for based on the offset from the target.
        Vector3 targetCamPos = target.position + offset;

        // Smoothly interpolate between the camera's current position and it's target position.
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.fixedDeltaTime);
    }
}