using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

//[RequireComponent(typeof(Animation))]

public class Player : BaseUnit
{
    [SerializeField]
    private float mInteractDist = 2f; // for debug purposue
    public bool isGrounded;
    
       
    public virtual void Start()
    {
        mAnimatorPlayer = GetComponent<Animator>();
        base.mNotDead = true;
        //mAnimatorPlayer.SetBool("Die", false);
    }

    public void Move(Vector2 direction)
    {

        Vector3 mMovement = new Vector3();

        mMovement.Set(direction.x, 0f, direction.y);
        mMovement = mMovement.normalized * mSpeed * Time.deltaTime;
        mMovement.x *= Mathf.Abs( direction.x );
        mMovement.y *= Mathf.Abs( direction.y );
        //  Räkna ut vector från vart spelaren är till vart spelaren ska
        Vector3 targetPos = (transform.position + mMovement) - transform.position;
        //  Normalisera den för att få enhetsvektor ( 0 -> 1 )
        targetPos.Normalize();
        // Omvandla vectorn från world space till local space
        var locVel = transform.InverseTransformDirection(targetPos);
        //Debug.Log(locVel);
        //  Skicka in framåthastigheten
        mAnimatorPlayer.SetFloat("FSpeed", mSpeed);
        mAnimatorPlayer.SetFloat("VSpeed", locVel.z * Mathf.Abs( direction.x ));
        mAnimatorPlayer.SetFloat("HSpeed", locVel.x * Mathf.Abs( direction.y ));
        mRigidBody.MovePosition(transform.position + mMovement);
    }


    //void Update()

    //{
    //    Vector3 mRayOrigin = transform.position + new Vector3(0, 1, 0);
    //    Ray mRay = new Ray(mRayOrigin, transform.forward);
    //    Debug.DrawRay(mRayOrigin, transform.forward * mInteractDist, Color.green);
    //}

    /*public override void Attack(BaseUnit target)
    {
        if (target.mNotDead)
        {            
            base.Attack(target);
            //mAnimatorPlayer.SetTrigger("Attacking");
            //base.ApplyDamage(mDamage);
            
        }
		

    }*/

    public void TriggerAttack()
    {
        Debug.Log("Triggered Attack");

        RaycastHit mRayHit;
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 2f;
        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), forward, out mRayHit, 5f) && mRayHit.transform.tag == "Enemy")
        {
            Debug.Log("Träff! " + mRayHit.transform.name);

            BaseUnit enemy = mRayHit.transform.GetComponent<BaseUnit>();
            if (enemy == null)
                Debug.LogError("Could not find component BaseUnit");
            this.Attack(enemy);
            //mPlayer.Attack(mRayHit.transform.GetComponent<Enemy>());
            //mPlayer.Attack();
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

    internal void ApplyDamage(object mDamage)
    {
        throw new NotImplementedException();
    }
}
