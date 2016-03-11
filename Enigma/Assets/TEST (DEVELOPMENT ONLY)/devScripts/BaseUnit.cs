﻿using UnityEngine;
using System.Collections;
/*

    // !!! DO NOT OPEN THIS SCRIPT !!!

    *** DISCLAIMER ***
    This script handels all base information and values for characters and are to be placed in the world as a GameObject by the name UNIT
    Script to be handeld by given resource until otherwise

    Notes:
    Commented out line 66. Se below for further information. / Maria

*/
[RequireComponent (typeof(Animation))] 
[RequireComponent(typeof(Rigidbody))]
public class BaseUnit : MonoBehaviour
{
    [SerializeField]
    protected int mHealth = 10; 
    [SerializeField]
    protected float mSpeed = 2;
    [SerializeField]
    protected float mAttackSpeed = 1;
    [SerializeField]
    protected float mAttackRange = 10f;
    [SerializeField]
    protected int mDamage = 3;
    [SerializeField]
    protected AnimationClip Attacking;     // Added by Maria 10/3 22:45

    private Animator mAnimator;     // Added by Maria 10/3 22:45
    Animation mAnimation;
    protected Rigidbody mRigidBody;

    private float mAttackSpeedCounter = 0.0f;

    void Awake()
    {
        mAnimation = GetComponent<Animation>();
        mRigidBody = GetComponent<Rigidbody>();
    }
        
    protected void PlayAnimation(string animationName)
    {
        mAnimation.Play(animationName, PlayMode.StopAll);
    }

    public virtual void Rotate(Quaternion rotation)
    {
        mRigidBody.MoveRotation(rotation);

    }
    
    void Update()
    {
       
    }

    public virtual void Die()
    {
        //Do not write here
    }

    public virtual void ApplyDamage(int damage)
    {
        mHealth -= damage;

        if (mHealth <= 0)
                Die();
    }

    public virtual void Attack(BaseUnit target)
    {
        mAnimation.Play("attack");
        mAttackSpeedCounter += Time.deltaTime;

        if(mAttackSpeedCounter >= mAttackSpeed)
        {
            target.ApplyDamage(mDamage);
            mAttackSpeedCounter = 0.0f;
        }


      

        //mAnimator.SetBool("Attacking", true);   // Added by Maria 10/3 22:45
        //mAnimation.Play("attack", PlayMode.StopAll);  *** This code is used only for 'Legacy' animations and is NOT compatible with the Player Character Animations! - Maria ***


    }

}
