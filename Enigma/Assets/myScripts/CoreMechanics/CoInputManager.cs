using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

public class CoInputManager : MonoBehaviour
{
    //Serialized variables below
    [SerializeField] private float mInteractRange;
    [SerializeField] float mCamRayLenght = 100f;
    [SerializeField] Rigidbody mRigidBody;
   
    //Private variables below
    private Player mPlayer;
    private int mFloorMask;
    private float mSpeed;
    Vector3 mMoveDirection = new Vector3();
  

    void Awake()
    {
        mFloorMask = LayerMask.GetMask("Floor");
        mPlayer = GetComponent<Player>();
        mRigidBody = GetComponent<Rigidbody>();
                   

    }//End Awake()

    void FixedUpdate()
    {
        HandleWASD();
        HandleMouse();
        OnMouseClick();
        //OnMouseEnter();
        //onMouseExit();
    }//End FixedUpdate()

    public void HandleWASD()
    {
        if(Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            mPlayer.Move(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
            mMoveDirection.Set(mMoveDirection.x, 0f, mMoveDirection.y);
            mMoveDirection = mMoveDirection.normalized * mSpeed * Time.deltaTime;
            mRigidBody.MovePosition(transform.position + mMoveDirection);
           
        }
    }

   

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
