using UnityEngine;
using System.Collections;

/*
*** [DISCLAIMER] ***

    PLEASE ADD DESCRIPTION AND COMMENTS

*/
[RequireComponent(typeof(Animation))]
[RequireComponent(typeof(Collider))]
public class ChestOpen : MonoBehaviour
{


    [SerializeField]
    private bool mChestOpen = false; //- [IF NECESSARY, REMOVE]    
    private Animation mAnimChest;
    private float mInteractDist = 20f;

    void Start()
    {
        mAnimChest = GetComponent<Animation>();
        mAnimChest["ChestAnim"].wrapMode = WrapMode.ClampForever;
    }

    void Update()
    {
        //Checks if player has clicked and if player is within collision, then play chest animation.
        if (Input.GetMouseButton(0) && !mChestOpen)
        {
            Ray ray = new Ray(transform.position, transform.right);
            RaycastHit hit;
            
            
            if (Physics.Raycast(ray, out hit, mInteractDist))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    gameObject.GetComponent<Collider>().enabled = false;
                    GetComponent<Animation>().Play("ChestAnim", PlayMode.StopAll);
                    mChestOpen = true;
                    Debug.Log("Chest Opened!");
                }
            }
        }
    }
}//End class ChestOpen
