using UnityEngine;
using System.Collections;

// Put the script on the camera. The destroyable object need a collider

public class DestroyBarrel : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) // When you click Left mouse button
        {
            Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition); // Targets the object you click on
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Destroy(hit.transform.gameObject); // Destroy object
            }
        }
    }

}