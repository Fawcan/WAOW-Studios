using UnityEngine;
using System.Collections;

/*
    Script by Maria and David
    [DISCLAIMER] ***
    
    ***SCRIPT IS UNDER DEVELOPMENT DO NOT OPEN OR WRITE CODE UNTIL OTHERWISE***
    - Add descritption and disclaimer for this script [X]
    - Script contains defined input systems and what the actions provide. []
    - Script is checked and uses at least one 'Debug.Log' statement []
    - Input in script is correspondent to its update function. []

    characterInputManager controls the given input and returns value to players movement represented.
    This script is independent and not to be inherited unless needed.
*/
//[RequireComponent(typeof(baseUnit))]
//To be put in Player.cs player : baseUnit
//player : characaterInputManager
public class CharacterInputManager : MonoBehaviour
{
    //CharacterController mController; - REMOVE WHEN DONE!
    Player mPlayer;
    private float mInteractRange;
    Rigidbody playerRigidbody;      // Reference to the player's rigidbody.
    int floorMask;                  // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
    float camRayLength = 100f;      // The length of the ray from the camera into the scene.

    //BaseObject m_baseObject;

    void Awake()
    {
    
         // Mouse is over the layer Floor and can be located
         floorMask = LayerMask.GetMask("Floor");
         playerRigidbody = GetComponent<Rigidbody>();
         // End of void Awake()

        mPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
	
    void FixedUpdate()
    {
        HandleWASD();
        HandleMouse();

        //GetComponent<BaseObject>().DoStuff(); - IN order to assign something without.
        
    }

    void HandleWASD()//Function for Keyboard WASD input
    {

        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            mPlayer.GetInput(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));


            //mPlayer.Move()


            //Function to end here

            /*      **[THIS TO BE PUT INTO BASEUNIT SCRIPT]**

                        if (Input.GetKey(KeyCode.W))
                    {
                        transform.Translate(Vector3.forward * mSpeed * Time.deltaTime);     // Transform so the player can move
                        GetComponent<Animation>().Play(run.name);                           // Running animation
                    }
                    if (Input.GetKey(KeyCode.A))
                    {
                        transform.Translate(Vector3.left * mSpeed * Time.deltaTime);
                        GetComponent<Animation>().Play(run.name);
                    }

                    if (Input.GetKey(KeyCode.S))
                    {
                        transform.Translate(Vector3.back * mSpeed * Time.deltaTime);
                        GetComponent<Animation>().Play(run.name);
                    }
                    if (Input.GetKey(KeyCode.D))
                    {
                        transform.Translate(Vector3.right * mSpeed * Time.deltaTime);
                        GetComponent<Animation>().Play(run.name);
                    }
                    */
        }
    }//End HandleWASD()


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
            playerRigidbody.MoveRotation(newRotatation);
        }
        
        
    }//End HandleMouse()

    void Interact()//preferable use tag "selectable" or "interaction". Function for interaction with objects
    {
        //Get click by racast
        //return the object from the raycast
        //Does the object have the correct tag?
        //Run the standard "DoStuff" on the object

        //if(Input.GetMouseButton(0))
        //{
        //    Vector3 mRayOrigin = transform.position + new Vector3(0, 1, 0);
        //    Ray mRay = new Ray(mRayOrigin, transform.forward);
        //}
        

    }//End Interact()


}