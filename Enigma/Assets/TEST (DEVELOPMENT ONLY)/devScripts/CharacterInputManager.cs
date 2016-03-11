using UnityEngine;
using System.Collections;


/*
    Script by Maria and David
    [DISCLAIMER] ***
    
    ***SCRIPT IS UNDER DEVELOPMENT DO NOT OPEN OR WRITE CODE UNTIL OTHERWISE***
    - Add descritption and disclaimer for this script [X]
    - Script contains defined input systems and what the actions provide. [X]
    - Script is checked and uses at least one 'Debug.Log' statement [X]
    - Input in script is correspondent to its update function. [X]

    CharacterInputManager controls the given input and returns value to players movement represented.
    This script is independent and not to be inherited unless needed.
*/
public class CharacterInputManager : MonoBehaviour
{
    private Player mPlayer;

    [SerializeField]
    private float mInteractRange;

    int floorMask;                  // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
    [SerializeField]
    float camRayLength = 100f;      // The length of the ray from the camera into the scene.

    void Awake()
    {
         // Mouse is over the layer Floor and can be located
        floorMask = LayerMask.GetMask("Floor");
        mPlayer = GetComponent<Player>();
    }
	
    void FixedUpdate()
    {
        //HandleWASD();
        HandleMouse();    

        //Ful lösning, använd inte!! 
        if(Input.GetMouseButton(0))
        {
            // Create a ray from the mouse cursor on screen in the direction of the camera.
            Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Create a RaycastHit variable to store information about what was hit by the ray.
            RaycastHit hit;

            // Perform the raycast and if it hits something on the floor layer...
            if (Physics.Raycast(camRay, out hit, camRayLength))
            {
                if(hit.transform.tag == "Enemy")
                {
                    mPlayer.Attack(hit.transform.GetComponent<BaseUnit>());

                }
            }
        }
    }

    //void HandleWASD()//Function for Keyboard WASD input
    //{
    //    if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
    //    {
    //        mPlayer.Move(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
    //    }
    //    //Bug reported to pivotal tracker and description is written - check next monday

    //}//End HandleWASD()

    void HandleMouse()//Function for mouse input
    {
        // Create a ray from the mouse cursor on screen in the direction of the camera.
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Create a RaycastHit variable to store information about what was hit by the ray.
        RaycastHit floorHit;

        // Perform the raycast and if it hits something on the floor layer...
        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            // Create a vector from the player to the point on the floor the raycast from the mouse hit.
            Vector3 playerToMouse = floorHit.point - transform.position;

            // Ensure the vector is entirely along the floor plane.
            playerToMouse.y = 0f;

            // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
            Quaternion newRotatation = Quaternion.LookRotation(playerToMouse);

            // Set the player's rotation to this new rotation.
            mPlayer.Rotate(newRotatation);
        }
        
        
    }//End HandleMouse()

    

    
}//End class CharacterInputManager