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
    private Color mColor;
    private Renderer mRenderer; 
    

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
        if(Input.GetButton("W") || Input.GetButton("S"))
        {
            transform.Translate(Vector3.forward * mSpeed * Time.deltaTime);
            transform.Translate(Vector3.back * mSpeed * Time.deltaTime);

        }

        if(Input.GetButton("A") || Input.GetButton("D"))
        {
            transform.Translate(Vector3.left * mSpeed * Time.deltaTime);
            transform.Translate(Vector3.right * mSpeed * Time.deltaTime);
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
