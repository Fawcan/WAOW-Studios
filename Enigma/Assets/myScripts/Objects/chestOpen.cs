using UnityEngine;
using System.Collections;

public class chestOpen : MonoBehaviour
{

    [SerializeField]
    private bool mChestOpen = false;
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
        
            
            Ray ray = new Ray(transform.position, transform.right);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, mInteractDist))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    

                    if (Input.GetMouseButton(0) && !mChestOpen)
                    {
                        //Debug.Log("klickad");
                       
                        gameObject.GetComponent<BoxCollider>().enabled = false;
                        GetComponent<Animation>().Play("ChestAnim");
                        mChestOpen = true;
                    }
                }
            }
    }
    
}
