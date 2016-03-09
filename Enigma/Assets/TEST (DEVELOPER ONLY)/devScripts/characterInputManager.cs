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
    player mPlayer;
    private float mInteractRange;

    
    
    void Awake()
    {
        mPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
    }
	void Start ()
    {
	
	}
	
    void HandleWASD()//Function for Keyboard WASD input
    {


    }

    void HandleMouse()//Function for mouse input
    {

    }

    void Interact()//preferable use tag "selectable" or "interaction". Function for interaction with objects
    {

    }

	void Update ()
    {
	
	}
}
