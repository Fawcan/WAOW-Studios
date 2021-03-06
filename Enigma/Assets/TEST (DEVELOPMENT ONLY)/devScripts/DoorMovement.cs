﻿using UnityEngine;
using System.Collections;

/*
    Script by Maria

    This script is used for door-movement when interacted by player.
    Attach to door.
    After adding this script, please add the tag 'Door' in the inspector
    of the Door prefab in order for this script to work with the 
    Door-interaction script.

*/

public class DoorMovement : MonoBehaviour
{
    [SerializeField]
    private bool mOpen = false;
    [SerializeField]
    private float mOpenAngle = 90f;
    
    //Variable commented out in case of later use, se desription on line 51.
    /*
    [SerializeField]
    private float mCloseAngle = 0f;
    */

    private float mSmooth = 2f;

	void Start ()
    {

    }

    public void ChangeDoorState()
    {
        mOpen = !mOpen;
    }
	
	void FixedUpdate ()
    {
        //Rotates the position of the door's Y-axis.
        if (mOpen)
        {
            Quaternion targetRotation = Quaternion.Euler(0, mOpenAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, mSmooth * Time.deltaTime);
        }

        /*
        The section below is not needed at this time but
        commented out in case of later use. The else statement
        would then be used for closing the door. Remember to
        uncomment the variable mCloseAnge as well.
        
        else
        {
            Quaternion targetRotation2 = Quaternion.Euler(0, mCloseAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation2, mSmooth * Time.deltaTime);
        }
        */

    }
}
