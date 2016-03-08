using UnityEngine;
using System.Collections;

public class BillBoard : MonoBehaviour {

    /*
    Script by Maria

        This Scipt is used for controlling the enemy healthbars
        to make sure that they will always face the mein camera 
        and not rotate when the enemy rotates. Please add this
        script as a component on the enemy-canvas and drag the 
        main camera to the mCamera slot.

    */

    public Camera mCamera;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.LookAt(transform.position + mCamera.transform.rotation * Vector3.back, mCamera.transform.rotation * Vector3.down); //If the healthbar is backwards try changing 'back' to 'front' or 'down' to 'up' on Vector3
	
	}
}
