using UnityEngine;
using System.Collections;

public class lightswitch : MonoBehaviour
{
    [SerializeField]
    private Light objLight;

    // check if somthing enters the trigger
    void OnTriggerEnter(Collider other)
    {
        // if its the Player
        if (other.gameObject.tag == "Player")
        {
            // turn on the light
            objLight.enabled = true;
        }
    }
    // check if somthing leaves the trigger
    void OnTriggerExit(Collider other)
    {
        // if its the Player
        if (other.gameObject.tag == "Player")
        {
            // turn off the light
            objLight.enabled = false;
        }
    }


}
