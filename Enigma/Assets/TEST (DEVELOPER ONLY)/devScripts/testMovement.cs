using UnityEngine;
using System.Collections;


/*
    **** WAOW STUDIOS **** 
    [DISCLAIMER]
    
    Script is just a testScript and are to be placed within the folder TEST(DEVELOPER ONLY) until further notice

    TO DO:
    - Retrieve the manager for input and assign the corresponding input to the player.
    - Check so that input is corresponding to input manager.

    *** THIS SCRIPT IS TO BE HANDELD BY ASSIGNED RESOURCE UNTIL OTHERWISE AND NOT TO BE EDITED WITHOUT PERMISSION ***
*/



[RequireComponent(typeof(CharacterController))] // Fetches the needed components from CharacterController manager script.
public class testMovement : MonoBehaviour
{
    public float mSpeed;
    public CharacterController controller;
    private Vector3 position;

    [SerializeField] private GameObject currentTarget;

    public AnimationClip run;
    public AnimationClip idle;

    void Start()
    {
        position = transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            // Locate where the player clicked on the terrain
            LocatePosition();
        }

        // Move the player to the position
        MoveToPosition();
    }
    void LocatePosition()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000))
        {
            currentTarget = null;

            if(hit.transform.tag == "Selectable")
            {
                currentTarget = hit.transform.gameObject;

                if (Vector3.Distance(gameObject.transform.position, hit.transform.position) < 5.0f)
                    Debug.Log("Attack!");

                //hit.transform.GetComponent<Enemy>().Damage(5.0f);

            }
            else if (hit.transform.tag == "Door")
            {
                //hit.transform.GetComponent<DoorScript>().OpenDoor();
            }
            else
                position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
        }
    }// End LocatePosition function

    void MoveToPosition()
    {
        // Game Object is moving
        if (Vector3.Distance(transform.position, position) > 1)
        {
            Quaternion newRotation = Quaternion.LookRotation(position - transform.position, Vector3.forward);

            // Locks the x and z axis so you only turn
            newRotation.x = 0f;
            newRotation.z = 0f;

            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 10);
            controller.SimpleMove(transform.forward * mSpeed);

            GetComponent<Animation>().CrossFade(run.name);

        }
        // Game Object is not moving
        else
        {
            GetComponent<Animation>().CrossFade(idle.name);

        }
    }

}//End Class
