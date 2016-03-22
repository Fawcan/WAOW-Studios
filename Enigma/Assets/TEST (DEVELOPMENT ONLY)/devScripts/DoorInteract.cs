using UnityEngine;
using System.Collections;

/*
    Script by Maria

    This script is used for player interaction with doors and when 
    player clicks on a door it activates the DoorMovementScipt.
    Attach to player.

*/
[RequireComponent(typeof(AudioSource))]
public class DoorInteract : MonoBehaviour
{
    [SerializeField]
    AudioClip DoorOpen;
    AudioSource audio;
    [SerializeField]
    private float mInteractDist = 10f; //This variable determines the distance from wich the player can interact with the door, needs tweaking. 

	void Start ()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update ()
    {
        

        //Checks if player has clicked and if player is within collision, then change door state.
        if (Input.GetButtonDown("Interact"))
        {
            Vector3 mRayOrigin = transform.position + new Vector3(0, 1, 0);

            Ray ray = new Ray(mRayOrigin, transform.forward);

            Debug.DrawRay(mRayOrigin, transform.forward * mInteractDist, Color.green);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, mInteractDist))
            {
                if (hit.collider.CompareTag("Door"))
                {
                    Debug.Log(hit.collider.gameObject.name);
                    
                    hit.collider.gameObject.GetComponent<DoorMovement>().ChangeDoorState();
                    GetComponent<AudioSource>().PlayOneShot(DoorOpen);

                    //hit.collider.transform.parent.BroadcastMessage("ChangeDoorState");
                }
            }
        }
	
	}
}
