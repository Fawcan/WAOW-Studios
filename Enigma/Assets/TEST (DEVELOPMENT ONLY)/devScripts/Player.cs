using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//[RequireComponent(typeof(Animation))]

public class Player : BaseUnit
{
    [SerializeField]
    private float mInteractDist = 2f; // for debug purposue
    public bool isGrounded;
       
    public virtual void Start()
    {
        mAnimatorPlayer = GetComponent<Animator>();
        //mAnimatorPlayer.SetBool("Die", false);
    }

    public void Move(Vector2 direction)
    {
        Vector3 mMovement = new Vector3();

        

        mMovement.Set(direction.x, 0f, direction.y);
        mMovement = mMovement.normalized * mSpeed * Time.deltaTime;
        //  Räkna ut vector från vart spelaren är till vart spelaren ska
        Vector3 targetPos = (transform.position + mMovement) - transform.position;
        //  Normalisera den för att få enhetsvektor ( 0 -> 1 )
        targetPos.Normalize();
        // Omvandla vectorn från world space till local space
        var locVel = transform.InverseTransformDirection(targetPos);
        //Debug.Log(locVel);
        //  Skicka in framåthastigheten
        mAnimatorPlayer.SetFloat("VSpeed", locVel.z);
        mAnimatorPlayer.SetFloat("HSpeed", locVel.x);
        mRigidBody.MovePosition(transform.position + mMovement);
    }


    //void Update()
    //{
    //    Vector3 mRayOrigin = transform.position + new Vector3(0, 1, 0);
    //    Ray mRay = new Ray(mRayOrigin, transform.forward);
    //    Debug.DrawRay(mRayOrigin, transform.forward * mInteractDist, Color.green);
    //}
    public override void Attack(BaseUnit target)
    {
        if(target.GetComponent<Enemy>().mNotDead && Input.GetButton("Attack"))
        {            
            base.Attack(target);
            mAnimatorPlayer.SetTrigger("Attacking");
            base.ApplyDamage(mDamage);
            
        }      

    }

    public override void Rotate(Quaternion rotation)
    {
        base.Rotate(rotation);
    }

    public override void Die()
    {
        //mAnimatorPlayer.SetBool("Die", true);
        mAnimatorPlayer.SetTrigger("Die");
        base.mNotDead = false;
        base.Die();       
        
        
    }


}
