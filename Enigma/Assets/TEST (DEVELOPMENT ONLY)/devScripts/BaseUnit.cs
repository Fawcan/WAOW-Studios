using UnityEngine;
using System.Collections;
/*

    // !!! DO NOT OPEN THIS SCRIPT !!!

    *** DISCLAIMER ***
    This script handels all base information and values for characters and are to be placed in the world as a GameObject by the name UNIT
    Script to be handeld by given resource until otherwise

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

    Animation mAnimation;
    protected Rigidbody mRigidBody;

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

    public virtual void Attack()
    {
        mAnimation.Play("attack", PlayMode.StopAll);
    }

}
