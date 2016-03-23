using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class RiverSound : MonoBehaviour
{

    [SerializeField]
    AudioClip RiverAmbience;
    AudioSource audio;
    bool mRiverPlaying = false;

    void Start()
    {
        audio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void OnTriggerEnter(Collider StartCave)
    {
        if (StartCave.CompareTag("Player") && !mRiverPlaying)
        {
            mRiverPlaying = true;
            GetComponent<AudioSource>().PlayOneShot(RiverAmbience);
            Debug.Log("Play");
        }
    }
}
