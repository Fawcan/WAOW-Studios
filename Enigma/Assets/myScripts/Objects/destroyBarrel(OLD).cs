using UnityEngine;
using System.Collections;

/*
**** WAOW STUDIOS **** 
     [DISCLAIMER]

    Put the script on the camera. The destroyable object need a collider and have the Tag "Destroyable"

    Notes:
    This script needs tweaking so the player have to be in range to destroy it

*** THIS SCRIPT IS TO BE HANDELD BY ASSIGNED RESOURCE UNTIL OTHERWISE AND NOT TO BE EDITED WITHOUT PERMISSION ***
*/

public class destroyBarrel : MonoBehaviour
{
    RaycastHit hit;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // When you click Left mouse button
        {
            Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition); // Targets the object you click on

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Destroyable") // Can only destroy objects with the tag "Destroyable"
                {
                    Destroy(hit.transform.gameObject); // Destroy object 
                }
            }
        }
    }
}