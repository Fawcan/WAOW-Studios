﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

//[RequireComponent(typeof(Animation))]

[RequireComponent(typeof(AudioSource))]
public class Player : BaseUnit
{
    [SerializeField]
    AudioClip EnemyHit;
    AudioSource audio;
    [SerializeField]
    private float mInteractDist = 2f; // for debug purposue
    public bool isGrounded;
    [SerializeField]
    protected UserInterface mUI;


    protected override int Health
    {
        get
        {
            return base.Health;
        }

        set
        {
            base.Health = value;
            mUI.CurrentHealth = Health;
        }
    }

    public virtual void Start()
    {
        audio = GetComponent<AudioSource>();

        mAnimatorPlayer = GetComponent<Animator>();
        base.mNotDead = true;
        //mAnimatorPlayer.SetBool("Die", false);
        mPlayer.GetComponent<CoInputManager>().enabled = true;
    }

    void Update()
    {
        if (mNotDead == false)
        {
            return;
        }
    }

    public void Move(Vector2 direction)
    {
        //Debug.Log(direction);
        Vector3 mMovement = new Vector3();
        Vector3 animationSpeed = new Vector3(direction.x, 0, direction.y);
        //animationSpeed.Normalize();
        //animationSpeed.x *= direction.x;
        //animationSpeed.y *= direction.y;

        mMovement.Set(direction.x, 0f, direction.y);
        mMovement = new Vector3(direction.x, 0, direction.y) * mSpeed * Time.deltaTime;
        Vector3 nonNormalizedMovement = mMovement;
        mMovement.x *= Mathf.Abs( direction.x );
        mMovement.y *= Mathf.Abs( direction.y );
        //  Räkna ut vector från vart spelaren är till vart spelaren ska
        //Vector3 targetPos = (transform.position + mMovement) - transform.position;
        //  Normalisera den för att få enhetsvektor ( 0 -> 1 )
        //targetPos.Normalize();
        // Omvandla vectorn från world space till local space

        var locVel = transform.InverseTransformDirection(animationSpeed);
        //Debug.Log(locVel);
        float speedZ = locVel.z;//(locVelFullSpeed.z == 0) ? 0 : locVel.z / locVelFullSpeed.z;
        float speedX = locVel.x;//(locVelFullSpeed.x == 0) ? 0 : locVel.x / locVelFullSpeed.x;

        //  Skicka in framåthastigheten
        mAnimatorPlayer.SetFloat("FSpeed", locVel.z);
        mAnimatorPlayer.SetFloat("VSpeed", speedZ);
        mAnimatorPlayer.SetFloat("HSpeed", speedX);
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
            GetComponent<AudioSource>().PlayOneShot(EnemyHit);

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
        mPlayer.GetComponent<CoInputManager>().enabled = false;
        //mAnimatorPlayer.SetBool("Die", true);
        mAnimatorPlayer.SetTrigger("Die");
        base.mNotDead = false;
        base.Die();
        StartCoroutine(StartDelay());
    }

    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    
    //internal void ApplyDamage(object mDamage)
    //{
    //    throw new NotImplementedException();
    //}
}
