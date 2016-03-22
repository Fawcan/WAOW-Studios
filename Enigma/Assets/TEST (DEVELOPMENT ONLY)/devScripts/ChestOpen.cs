using UnityEngine;
using System.Collections;

/*
*** [DISCLAIMER] ***

    PLEASE ADD DESCRIPTION AND COMMENTS

*/
[RequireComponent(typeof(Animation))]
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(AudioSource))]
public class ChestOpen : MonoBehaviour
{

    [SerializeField]
    AudioClip ChestAudio;
    AudioSource audio;
    [SerializeField]
    private bool mChestOpen = false; //- [IF NECESSARY, REMOVE]    
    private Animation mAnimChest;
    [SerializeField]
    private float mInteractDist = 1f;
    

    void Start()
    {
        mAnimChest = GetComponent<Animation>();
        mAnimChest["ChestAnim"].wrapMode = WrapMode.ClampForever;
        audio = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        //Checks if player has clicked and if player is within collision, then play chest animation.

       
        if (Input.GetButton("Interact") && !mChestOpen)
        {
            Ray ray = new Ray(transform.position, transform.right);
            RaycastHit hit;
            //Debug.Log("Klickad");


            if (Physics.Raycast(ray, out hit, mInteractDist))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    Debug.Log("CHEST IS CLICKED!");
                    //gameObject.GetComponent<Collider>().enabled = false;                    
                    GetComponent<Animation>().Play("ChestAnim", PlayMode.StopAll);
                    GetComponent<AudioSource>().PlayOneShot(ChestAudio);
                    Debug.Log("ANIMATION IS PLAYED!");
                    mChestOpen = true;
                    Debug.Log("CHEST OPENED!");
                }
            }
        }
    }
}//End class ChestOpen
