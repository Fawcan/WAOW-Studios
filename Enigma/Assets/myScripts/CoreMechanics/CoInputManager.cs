using UnityEngine;
using System.Collections;

public class CoInputManager : MonoBehaviour
{
    //Serialized variables below
    [SerializeField] private float mInteractRange;
    [SerializeField] float mCamRayLenght = 100f;

    //Private variables below
    private Player mPlayer;
    private int mFloorMask;
    private float mSpeed;

    void Awake()
    {
        mFloorMask = LayerMask.GetMask("Floor");
        mPlayer = GetComponent<Player>();

    }//End Awake()

    void FixedUpdate()
    {
        HandleWASD();
        HandleMouse();
        OnMouseClick();
        //OnMouseEnter();
        //onMouseExit();
    }//End FixedUpdate()

    void HandleWASD()
    {
        if(Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            mPlayer.Move();
        }
    }//End HandleWASD()

    void HandleMouse()
    {
        Ray mCamRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit mFloorHit;

        if(Physics.Raycast(mCamRay, out mFloorHit, mCamRayLenght, mFloorMask))
        {
            Vector3 mPlayerToMouse = mFloorHit.point - transform.position;
            mPlayerToMouse.y = 0f;

            Quaternion mNewRotate = Quaternion.LookRotation(mPlayerToMouse);
            mPlayer.Rotate(mNewRotate);

            if(mFloorHit.transform.tag == "Enemy")
            {
                mPlayer.Attack(mFloorHit.transform.GetComponent<BaseUnit>());
            }

        
            
        }
    }//End HandleMouse()

    void OnMouseClick()
    {
        
        if (Input.GetMouseButton(0))
        {
            Debug.Log("Mousebutton left is clicked");
            HandleMouse();            
        }
    }//End OnMouseClick()

    




}
