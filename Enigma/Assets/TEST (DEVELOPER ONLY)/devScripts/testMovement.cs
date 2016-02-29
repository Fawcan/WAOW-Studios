using UnityEngine;
using System.Collections;

public class testMovement : MonoBehaviour
{
    public float mSpeed;
    public CharacterController controller;
    private Vector3 position;

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
            position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
        }
    }

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

}
