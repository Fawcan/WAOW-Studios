using UnityEngine;
using System.Collections;

public class ResetGame : MonoBehaviour
{
    void Update ()
    {
        if(Input.GetButtonDown("Interact"))
        {
            Application.LoadLevel("FirstLevel");
            Debug.Log("Reset");
        }
	}
}
