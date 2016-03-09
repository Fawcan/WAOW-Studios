using UnityEngine;
using System.Collections;

public class DamageObjectScript : MonoBehaviour {

    RaycastHit hit;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // When you click Left mouse button
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Targets the object you click on

            if (Physics.Raycast(ray, out hit))
            {
                if (Vector3.Distance(transform.position, hit.transform.position) < 2.0f)
                {

                    if (hit.collider.tag == "Destroyable") // Can only destroy objects with the tag "Destroyable"
                    {
                        hit.transform.GetComponent<Barrel>().DamageBarrel(1);
                    }
                }
            }
        }
    }
}
