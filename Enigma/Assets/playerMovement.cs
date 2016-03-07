using UnityEngine;
using System.Collections;

/*
**** WAOW STUDIOS **** 
     [DISCLAIMER]

    This script includes the movement for the player with the controls WASD and so the players rotation follows the camera
    You need to name the terrain Floor and put it in a Floor layer

    Notes:

*** THIS SCRIPT IS TO BE HANDELD BY ASSIGNED RESOURCE UNTIL OTHERWISE AND NOT TO BE EDITED WITHOUT PERMISSION ***
*/

public class playerMovement : MonoBehaviour
{
    [SerializeField]
    CharacterController controller; // The Players Character Controller
    Rigidbody playerRigidbody;      // Reference to the player's rigidbody.
    int floorMask;                  // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
    float camRayLength = 100f;      // The length of the ray from the camera into the scene.
    float mSpeed = 2.25f;

    // Run and idle animation for the player character.
    [SerializeField]
    AnimationClip run;
    [SerializeField]
    AnimationClip idle;

    void Awake()
    {
        // Mouse is over the layer Floor and can be located
        floorMask = LayerMask.GetMask("Floor");
        playerRigidbody = GetComponent<Rigidbody>();
    } // End of void Awake()


    // For the WASD movement input
    void Update()
    {
        // Idle animation
        GetComponent<Animation>().CrossFade(idle.name);

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
    } // End of void Update()

    void FixedUpdate()
    {
        // Turn the player to face the mouse cursor.
        Turning();
    } // End of void FixedUpdate()

    void Turning()
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
    } // End of void Turning()
}