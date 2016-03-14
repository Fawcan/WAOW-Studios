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
    private Vector3 Move;

    void Awake()
    {
        mFloorMask = LayerMask.GetMask("Floor");
        mPlayer = GetComponent<Player>();            

    }//End Awake()

    void FixedUpdate()
    {
        float mMoveH = Input.GetAxisRaw("Horizontal");
        float mMoveV = Input.GetAxisRaw("Vertical");
        HandleWASD(mMoveH, mMoveV);
        HandleMouse();
        OnMouseClick();
        
        //OnMouseEnter();
        //onMouseExit();
    }//End FixedUpdate()

    void HandleWASD(float h, float v)
    {

        //Move.Set(h, 0f, v);
        //Move = Move.normalized * mSpeed * Time.deltaTime;
        //mPlayer.GetComponent<Rigidbody>();
        ////if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        ////{
        ////    mPlayer.Move(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));

        ////}
        //mPlayer.transform


     
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
