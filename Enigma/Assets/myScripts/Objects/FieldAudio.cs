using UnityEngine;
using System.Collections;


[RequireComponent(typeof(AudioSource))]
public class FieldAudio : MonoBehaviour
{
    [SerializeField]
    AudioClip FieldSound;
    AudioSource audio;
    bool mCavePlaying = false;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        GetComponent<AudioSource>().PlayOneShot(FieldSound);
        Debug.Log("Once");
    }

    void OnTriggerExit(Collider StartCave)
    {
        if (StartCave.CompareTag("Player") && !mCavePlaying)
        {
            audio.Stop();
            mCavePlaying = true;
            Debug.Log("Cave");
        }
    }
    void OnTriggerEnter(Collider EndCave)
    {
        if (EndCave.CompareTag("Player") && mCavePlaying)
        {
            mCavePlaying = false;
            GetComponent<AudioSource>().PlayOneShot(FieldSound);
            Debug.Log("Field");
        }
    }
}
