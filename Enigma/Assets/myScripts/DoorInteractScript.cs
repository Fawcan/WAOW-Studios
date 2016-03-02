using UnityEngine;
using System.Collections;

/*
    Script by Maria

    This script is used for player interaction with doors and when 
    player clicks on a door it activates the DoorMovementScipt.
    Attach to player.

*/

public class DoorInteractScript : MonoBehaviour {

    [SerializeField]
    private float mInteractDist = 8f; //This variable determines the distance from wich the player can interact with the door, needs tweaking. 

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Checks if player has clicked and if player is within collision, then change door state.
        if (Input.GetMouseButton(0))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, mInteractDist))
            {
                if(hit.collider.CompareTag("Door"))
                {
                    hit.collider.transform.parent.GetComponent<DoorMovementScript>().ChangeDoorState();
                }
            }
        }
	
	}
}
