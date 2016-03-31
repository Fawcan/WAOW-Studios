using UnityEngine;
using System.Collections;


[RequireComponent(typeof(AudioSource))]
public class AmbienceAudio : MonoBehaviour
{
    [SerializeField]
    AudioClip FieldSound;
    [SerializeField]
    AudioClip CaveAmbience;
    AudioSource FieldAudio;
    AudioSource CaveAudio;
    bool mCavePlaying = false;


    void Start()
    {
        FieldAudio = GetComponent<AudioSource>();
        CaveAudio = GetComponent<AudioSource>();
        GetComponent<AudioSource>().PlayOneShot(FieldSound);
        Debug.Log("Once");
    }

    void OnTriggerEnter(Collider StartCave)
    {
        if (StartCave.CompareTag("Player") && !mCavePlaying)
        {
            FieldAudio.Stop();

            mCavePlaying = true;
            GetComponent<AudioSource>().PlayOneShot(CaveAmbience);
            CaveAudio.loop = true;
            Debug.Log("Cave");

        }
    }
    void OnTriggerExit(Collider EndCave)
    {
        if (EndCave.CompareTag("Player") && mCavePlaying)
        {
            mCavePlaying = false;
            //GetComponent<AudioSource>().PlayOneShot(CaveAmbience);
            CaveAudio.Stop();
            GetComponent<AudioSource>().PlayOneShot(FieldSound);
            FieldAudio.loop = true;
            Debug.Log("Field");

        }
    }
}
