using UnityEngine;
using System.Collections;

public class Lightswitch : MonoBehaviour
{
    [SerializeField] private Light mObjLight;
    

    // check if somthing enters the trigger
    void OnTriggerEnter(Collider other)
    {
        // if its the Player
        if (other.gameObject.tag == "Player")
        {
            // turn on the light
            mObjLight.enabled = true;
        }
    }
    // check if somthing leaves the trigger
    void OnTriggerExit(Collider other)
    {
        // if its the Player
        if (other.gameObject.tag == "Player")
        {
            // turn off the light
            mObjLight.enabled = false;
        }
    }


}
