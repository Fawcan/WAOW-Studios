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
    private int mPlayerInput;
  

    void Awake()
    {
        mFloorMask = LayerMask.GetMask("Floor");
        mPlayer = GetComponent<Player>();
        mRigidBody = GetComponent<Rigidbody>();
                   

    }//End Awake()

    void FixedUpdate()
    {
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

    public void HandleRotation()
    {
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
