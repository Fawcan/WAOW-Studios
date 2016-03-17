using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]

public class CoInputManager : MonoBehaviour
{
    //Serialized variables below
    [SerializeField] private float mInteractRange;
    [SerializeField] float mCamRayLenght = 100f;
    [SerializeField] Rigidbody mRigidBody;    
   
    //Private variables below
    private Player mPlayer;
    private Animator mAnimator;
    private int mFloorMask;
    private float mSpeed;
    //Public variables below
    public float mRotationSpeed = 100f;
  

    void Awake()
    {
        mFloorMask = LayerMask.GetMask("Floor");
        mPlayer = GetComponent<Player>();
        mAnimator = GetComponent<Animator>();

    }//End Awake()

    void LateUpdate()
    {              
        HandleInput();
        HandleRotation();
        ButtonResponse();
                
    }//End FixedUpdate()

    public void HandleInput()
    {
         mPlayer.Move(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
       
    } //End HandleInput 

    public void HandleRotation()
    {
        float horMovement = Input.GetAxis("CameraRotateX");
        float verMovement = Input.GetAxis("CameraRotateY");
        Vector2 rightAnalogue = new Vector2(horMovement, verMovement);
        if(rightAnalogue.magnitude > 0.5f)
        //if (rightAnalogue != Vector2.zero)
        {
            rightAnalogue.Normalize();
            transform.LookAt(new Vector3(transform.position.x + rightAnalogue.x, transform.position.y, transform.position.z + rightAnalogue.y));
        }
        else
        {
            Vector2 moveVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            if (moveVector != Vector2.zero)
            {
                transform.LookAt(new Vector3(transform.position.x + moveVector.x, transform.position.y, transform.position.z + moveVector.y));
            }
            
        }        
    }// End HandleRotation()

    void ButtonResponse()
    {
        if (Input.GetButtonDown("Attack"))
        {
            mAnimator.SetTrigger("Attacking");
            Debug.Log("Attacking!");
        }
    }

}// End Class
