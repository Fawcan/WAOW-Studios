using UnityEngine;
using System.Collections;


[RequireComponent(typeof(AudioSource))]
public class CaveSound : MonoBehaviour
{
    [SerializeField]
    AudioClip CaveAmbience;
    [SerializeField]
    AudioClip FieldSound;
    AudioSource audio;
    bool mCavePlaying = false;

    void Start ()
    {
        audio = GetComponent<AudioSource>();
        GetComponent<AudioSource>().PlayOneShot(FieldSound);

    }

    // Update is called once per frame
    void OnTriggerEnter(Collider StartCave)
    {
        audio.Stop();
        if (StartCave.CompareTag("Player") && !mCavePlaying)
        {
            mCavePlaying = true;
            GetComponent<AudioSource>().PlayOneShot(CaveAmbience);
            Debug.Log("Play");
        }
    }
    void OnTriggerExit(Collider EndCave)
    {
        if (EndCave.CompareTag("Player") && mCavePlaying)
        {
            mCavePlaying = false;
            //GetComponent<AudioSource>().PlayOneShot(CaveAmbience);
            audio.Stop();
            GetComponent<AudioSource>().PlayOneShot(FieldSound);

            Debug.Log("Stop");

        }
    }
}
