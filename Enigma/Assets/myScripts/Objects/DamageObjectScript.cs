using UnityEngine;
using System.Collections;

/*
This script works as of 22/3-16
// Albin
*/

[RequireComponent(typeof(AudioSource))]
public class DamageObjectScript : MonoBehaviour
{
    [SerializeField]
    AudioClip BarrelBreak;
    AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Working script that allows you to destroy objects with the controller
    void OnTriggerEnter (Collider DestroyObject)
    {
        if (DestroyObject.CompareTag("Destroyable"))
        {
            if (Input.GetButton("Attack"))
            {
                Destroy(DestroyObject.gameObject);
                GetComponent<AudioSource>().PlayOneShot(BarrelBreak);

            }
        }
    }

    // Old Raycast script to destroy objects

    //RaycastHit hit;

    //void Update()
    //{
    //    if (Input.GetMouseButtonDown(0)) // When you click Left mouse button
    //    {
    //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Targets the object you click on

    //        if (Physics.Raycast(ray, out hit))
    //        {
    //            if (Vector3.Distance(transform.position, hit.transform.position) < 1.0f)  // Checks distance between player and target
    //            {

    //                if (hit.collider.tag == "Destroyable") // Can only destroy objects with the tag "Destroyable"
    //                {
    //                    hit.transform.GetComponent<Barrel>().DamageBarrel(1);   // Deals damage to barrel
    //                }
    //            }
    //        }
    //    }
    //}
}
