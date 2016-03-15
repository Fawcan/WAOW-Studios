using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

public class CoInputManager : MonoBehaviour
{
    //Serialized variables below
    [SerializeField] private float mInteractRange;
    [SerializeField] float mCamRayLenght = 100f;

    //Private variables below
    private Player mPlayer;
    private int mFloorMask;
    private float mSpeed;
    Rigidbody mRigidBody;
    private Vector3 mMoveDirection = Vector3.zero;
  

    void Awake()
    {
        mFloorMask = LayerMask.GetMask("Floor");
        mPlayer = GetComponent<Player>();
        mRigidBody = GetComponent<Rigidbody>();
     
                    

    }//End Awake()

    void LateUpdate()
    {
        //float mMoveH = Input.GetAxisRaw("Horizontal");
        //float mMoveV = Input.GetAxisRaw("Vertical");
        HandleWASD();
        HandleMouse();
        OnMouseClick();
        
        //OnMouseEnter();
        //onMouseExit();
    }//End FixedUpdate()

    void HandleWASD()
    {

        //Move.Set(h, 0f, v);
        //Move = Move.normalized * mSpeed * Time.deltaTime;
        //mPlayer.GetComponent<Rigidbody>();
        //if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        //{
        //    mPlayer.GetComponent<Rigidbody>();
        //    mPlayer.Move(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
        //    mPlayer.transform.Translate(Vector3.up * mSpeed * Time.deltaTime);

        //}
        //if(Input.GetKey(KeyCode.W))
        //{
        //    transform.Translate(Vector2.up * mSpeed * Time.deltaTime);
        //    mPlayer.GetComponent<Player>();
        //}
        mPlayer.Move(mMoveDirection);
        if(mPlayer.isGrounded)
        {
            mMoveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            mMoveDirection = transform.TransformDirection(mMoveDirection);
            mMoveDirection *= mSpeed;
            mPlayer.Move(mMoveDirection * Time.deltaTime);

            
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
