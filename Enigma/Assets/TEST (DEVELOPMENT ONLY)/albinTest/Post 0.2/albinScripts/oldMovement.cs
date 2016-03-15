using UnityEngine;
using System.Collections;

public class oldMovement : MonoBehaviour
{

    public float mSpeed;
    public CharacterController controller;
    private Vector3 position;
    //public float hSpeed;

    int floorMask;                  // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
    //public AnimationClip run;
    //public AnimationClip idle;

    void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
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

    void FixedUpdate()
    {
        Ray ray = new Ray(transform.position, transform.right);
        RaycastHit hit;


        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("Works");
            }
        }
    }
    void LocatePosition()
    {

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


        if (Physics.Raycast(ray, out hit, 1000))
        {
            position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            position.y = 0f;
        }
    }

    void MoveToPosition()
    {
        RaycastHit floorHit;
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(camRay, out floorHit, floorMask))
        {
            if (floorHit.collider.CompareTag("Floor"))
            {


                // Game Object is moving
                if (Vector3.Distance(transform.position, position) > .5)
                {



                    //Vector3 mRayOrigin = transform.position + new Vector3(0, 1, 0);

                    //Ray ray = new Ray(mRayOrigin, transform.forward);

                    //RaycastHit hit;

                    //if (Physics.Raycast(ray, out hit, mInteractDist))

                    //{
                    //if (Physics.Raycast(ray, out hit))
                    //{
                    //if (hit.collider.tag == "Floor")
                    //{

                    //Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

                    //RaycastHit floorHit;

                    //if (Physics.Raycast(camRay, out floorHit, floorMask))
                    //{
                    //if (Physics.Raycast(camRay, out floorHit, floorMask))
                    //{


                    Quaternion newRotation = Quaternion.LookRotation(position - transform.position, Vector3.forward);

                    // Locks the x and z axis so you only turn
                    newRotation.x = 0f;
                    newRotation.z = 0f;

                    float step = mSpeed * Time.deltaTime;

                    transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 10);
                    transform.position = Vector3.MoveTowards(transform.position, position, step);
                    //Debug.Log("Walking");
                    //controller.SimpleMove(transform.forward * mSpeed);
                    //}
                    //}
                    //GetComponent<Animation>().CrossFade(run.name);
                    //}
                }
                // Game Object is not moving
                else
                {
                    //GetComponent<Animation>().CrossFade(idle.name);
                }
            }
        }
    }
}
//}
