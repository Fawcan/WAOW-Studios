using UnityEngine;
using System.Collections;

public class testMovement : MonoBehaviour
{
    [SerializeField]
    float mSpeed;
    [SerializeField]
    CharacterController controller;
    [SerializeField]
    Rigidbody playerRigidbody;
    private Vector3 position;
    int floorMask;                  // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
    float camRayLength = 100f;      // The length of the ray from the camera into the scene.

    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

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
            position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
        }
    }

    void MoveToPosition()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);


        RaycastHit floorHit;

        // Game Object is moving

        // Perform the raycast and if it hits something on the floor layer...
        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            if (Vector3.Distance(transform.position, position) > 1)
            {
                // Create a vector from the player to the point on the floor the raycast from the mouse hit.
                Vector3 playerToMouse = floorHit.point - transform.position;

                // Ensure the vector is entirely along the floor plane.
                playerToMouse.y = 0f;
                Quaternion newRotation = Quaternion.LookRotation(position - transform.position, Vector3.forward);

                // Locks the x and z axis so you only turn
                newRotation.x = 0f;
                newRotation.z = 0f;

                transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 10);
                controller.SimpleMove(transform.forward * mSpeed);
                Quaternion newRotatation = Quaternion.LookRotation(playerToMouse);

                playerRigidbody.MoveRotation(newRotatation);

            }
        }

    }

}