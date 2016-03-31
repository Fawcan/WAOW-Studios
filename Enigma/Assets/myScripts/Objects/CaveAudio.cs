using UnityEngine;
using System.Collections;


[RequireComponent(typeof(AudioSource))]
public class CaveAudio : MonoBehaviour
{
    [SerializeField]
    AudioClip CaveSound;
    AudioSource audio;
    bool mFieldPlaying = false;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        GetComponent<AudioSource>().PlayOneShot(CaveSound);
        Debug.Log("Once");
    }

    void OnTriggerExit(Collider StartCave)
    {
        if (StartCave.CompareTag("Player") && !mFieldPlaying)
        {
            audio.Stop();
            mFieldPlaying = true;
            Debug.Log("Cave");
        }
    }
    void OnTriggerEnter(Collider EndCave)
    {
        if (EndCave.CompareTag("Player") && mFieldPlaying)
        {
            mFieldPlaying = false;
            GetComponent<AudioSource>().PlayOneShot(CaveSound);
            Debug.Log("Field");
        }
    }
}
