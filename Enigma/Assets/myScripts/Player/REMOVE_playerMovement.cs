using UnityEngine;
using System.Collections;

/*
**** WAOW STUDIOS **** 
     [DISCLAIMER]

OBSOLETE SCRIPT



*** THIS SCRIPT IS TO BE HANDELD BY ASSIGNED RESOURCE UNTIL OTHERWISE AND NOT TO BE EDITED WITHOUT PERMISSION ***
*/

public class REMOVE_playerMovement : MonoBehaviour
{

    public CharacterController controller;
    //private Vector3 position;

    // Run and idle animation for the player character.
    public AnimationClip run;
    public AnimationClip idle;


    // For the WASD movement input
    void Update()
    {

        // Idle animation
        GetComponent<Animation>().CrossFade(idle.name);

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime);
            GetComponent<Animation>().Play(run.name);
        }
        /*if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime);
            GetComponent<Animation>().Play(run.name);
        }*/

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime);
            GetComponent<Animation>().Play(run.name);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime);
            GetComponent<Animation>().Play(run.name);
        }
        /*if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime);
            GetComponent<Animation>().Play(run.name);
        }*/

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime);
            GetComponent<Animation>().Play(run.name);
        }

    } // End of Void Update()
}