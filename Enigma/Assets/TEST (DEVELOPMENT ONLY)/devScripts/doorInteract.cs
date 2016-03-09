using UnityEngine;
using System.Collections;

/*
    Script by Maria

    This script is used for player interaction with doors and when 
    player clicks on a door it activates the DoorMovementScipt.
    Attach to player.

*/

public class doorInteract : MonoBehaviour {

    [SerializeField]
    private float mInteractDist = 10f; //This variable determines the distance from wich the player can interact with the door, needs tweaking. 

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        

        //Checks if player has clicked and if player is within collision, then change door state.
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Klickad");


            Vector3 mRayOrigin = transform.position + new Vector3(0, 1, 0);

            Ray ray = new Ray(mRayOrigin, transform.forward);

            //Debug.DrawRay(rayorigin, transform.forward * mInteractDist, Color.green);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, mInteractDist))
                
            {
                

                if (hit.collider.CompareTag("Door"))
                {
                    //Debug.Log(hit.collider.gameObject.name);
                    
                    hit.collider.gameObject.GetComponent<doorMovement>().ChangeDoorState();
                    //hit.collider.transform.parent.BroadcastMessage("ChangeDoorState");
                }
            }
        }
	
	}
}
