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
public class characterInputManager : MonoBehaviour
{
    CharacterController mController;
    player mPlayer;
    private float mInteractRange;

    BaseObject m_baseObject;
    
    void Awake()
    {
        mPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
    }
	void Start ()
    {
	
	}

    void Update()
    {
        HandleWASD();

        //Get click by racast
        //return the object from the raycast
        //Does the object have the correct tag?
        //Run the standard "DoStuff" on the object

        GetComponent<BaseObject>().DoStuff();
    }

    void HandleWASD()//Function for Keyboard WASD input
    {

        if(Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
            mPlayer.GetInput(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));



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


    }

    void HandleMouse()//Function for mouse input
    {

    }

    void Interact()//preferable use tag "selectable" or "interaction". Function for interaction with objects
    {

    }


}
