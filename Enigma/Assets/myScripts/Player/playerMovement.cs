using UnityEngine;
using System.Collections;

/*
**** WAOW STUDIOS **** 
     [DISCLAIMER]

    This script includes the movement for the player with the controls WASD.
    The players rotation follows the mouse

This is the final movement code


*** THIS SCRIPT IS TO BE HANDELD BY ASSIGNED RESOURCE UNTIL OTHERWISE AND NOT TO BE EDITED WITHOUT PERMISSION ***
*/

public class playerMovement : MonoBehaviour
{
    public float mSpeed;
    public CharacterController controller;
    private Vector3 position;

    // Run and idle animation for the player character.
    public AnimationClip run;
    public AnimationClip idle;


    // For the WASD movement input
    void Update()
    {

        // Idle animation
        GetComponent<Animation>().CrossFade(idle.name);


        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime);
            GetComponent<Animation>().Play(run.name);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime);
            GetComponent<Animation>().Play(run.name);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime);
            GetComponent<Animation>().Play(run.name);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime);
            GetComponent<Animation>().Play(run.name);
        }
    } // End of Void Update()


    void LocatePosition()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000))
        {
            if (Vector3.Distance(gameObject.transform.position, hit.transform.position) < 5.0f) ;
            //hit.transform.GetComponent<Enemy>().Damage(5.0f);
        }
        else if (hit.transform.tag == "Door")
        {
            //hit.transform.GetComponent<DoorScript>().OpenDoor();
        }
        else
        {
            position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
        }
    }// End LocatePosition function

    void LooksAtMouse()
    {
        Quaternion newRotation = Quaternion.LookRotation(position - transform.position, Vector3.forward);

        // Locks the x and z axis so you only turn
        newRotation.x = 0f;
        newRotation.z = 0f;

        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 10);
        controller.SimpleMove(transform.forward * mSpeed);
    }
}