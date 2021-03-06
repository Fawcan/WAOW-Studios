﻿using UnityEngine;
using System.Collections;


[RequireComponent(typeof(AudioSource))]
public class AmbienceAudio : MonoBehaviour
{
    [SerializeField]
    AudioClip FieldSound;
    [SerializeField]
    AudioClip CaveAmbience;
    AudioSource audio;
    bool mCavePlaying = false;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        //GetComponent<AudioSource>().PlayOneShot(FieldSound);
        Debug.Log("Once");
    }

    void OnTriggerEnter(Collider StartCave)
    {
        if (StartCave.CompareTag("Player") && !mCavePlaying)
        {
            audio.Stop();

            mCavePlaying = true;
            GetComponent<AudioSource>().PlayOneShot(CaveAmbience);
            audio.loop = true;
            Debug.Log("Cave");
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
            audio.loop = true;
            Debug.Log("Field");
        }
    }
}
