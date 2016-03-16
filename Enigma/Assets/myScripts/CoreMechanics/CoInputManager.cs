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
    //Vector3 mMoveDirection = new Vector3();
    //private int mPlayerInput;
    //private bool mRotating = false;
    //private float mPrevAngle = 0.0f;

    public float mRotationSpeed = 100f;
  

    void Awake()
    {
        mFloorMask = LayerMask.GetMask("Floor");
        mPlayer = GetComponent<Player>();
        mRigidBody = GetComponent<Rigidbody>();
                   

    }//End Awake()

    void FixedUpdate()
    {
        
        //Debug.Log(Input.GetAxisRaw("CameraRotateX"));
        HandleWASD();
        HandleMouseInput();
        OnMouseClick();
        HandleRotation();
        //OnMouseEnter();
        //onMouseExit();
    }//End FixedUpdate()

    public void HandleWASD()
    {
         mPlayer.Move(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
    }

    void HandleMouseInput()
    {
        //Ray mCamRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit mFloorHit;
        //if(Physics.Raycast(mCamRay, out mFloorHit, mCamRayLenght, mFloorMask))
        //{
        //    Vector3 mPlayerToMouse = mFloorHit.point - transform.position;
        //    mPlayerToMouse.y = 0f;

        //    Quaternion mNewRotate = Quaternion.LookRotation(mPlayerToMouse);
        //    mPlayer.Rotate(mNewRotate);

        //    if(mFloorHit.transform.tag == "Enemy")
        //    {
        //        mPlayer.Attack(mFloorHit.transform.GetComponent<BaseUnit>());
        //    }

            
        //}
    }//End HandleMouse()

    public void HandleRotation()
    {
        Vector2 rightAnalogue = new Vector2(Input.GetAxis("CameraRotateX"), Input.GetAxis("CameraRotateY"));
        rightAnalogue.Normalize();
        transform.LookAt(new Vector3(transform.position.x + rightAnalogue.x, transform.position.y, transform.position.z + rightAnalogue.y));
        
        //float Axis5 = Input.GetAxis("CameraRotate");
        //Debug.Log("Axis 5");



        //float mHor = Input.GetAxisRaw("Horizontal");
        //float mVer = Input.GetAxisRaw("Vertical");

        //if(mRotating)
        //{
        //    if(Mathf.Abs(mHor) < 0.99f && Mathf.Abs(mVer) < 0.99f)
        //    {
        //        mRotating = false;
        //        return;
        //    }
        //    float mAngle = Mathf.Atan2(mVer, mHor) * Mathf.Rad2Deg;
        //    transform.Rotate(0.0f, 0.0f, -(mAngle - mPrevAngle));
        //    mPrevAngle = mAngle;
        //}
        //else
        //{
        //    if(Mathf.Abs(mHor) > 0.99f || Mathf.Abs(mVer) > 0.99f)
        //    {
        //        mPrevAngle = Mathf.Atan2(mVer, mHor) * Mathf.Rad2Deg;
        //        mRotating = true;
        //    }
        //}
        //Read the axis of the controller
        //Send to mPlayer.Rotate(Quaternion):
        //mPlayer.Rotate();
    }

    void OnMouseClick()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("Mousebutton left is clicked");
            HandleMouseInput();            
        }
    }//End OnMouseClick()

    




}
