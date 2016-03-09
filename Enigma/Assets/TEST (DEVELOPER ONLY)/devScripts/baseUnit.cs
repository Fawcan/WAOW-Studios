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
    float mSpeed = 2;
    [SerializeField]
    float mAttackSpeed = 1;
    [SerializeField]
    float mAttackRange = 10f;
    [SerializeField]
    int mDamage = 3;

    Animation mAnimation;
    Rigidbody mRigidBody;

    void Awake()
    {
        mAnimation = GetComponent<Animation>();
        mRigidBody = GetComponent<Rigidbody>();
    }
        
    public virtual void Move(Vector2 direction)
    {
        transform.Translate(new Vector3(direction.x,0, direction.y) * mSpeed * Time.deltaTime);     // Transform so the player can move
        mAnimation.Play("Run", PlayMode.StopAll);
    }

    public virtual void Rotate(Quaternion rotation)
    {
        mRigidBody.MoveRotation(rotation);

    }
    
    public virtual void Die()
    {
        //Do not write here
    }

    public virtual void Attack()
    {
        //Do not write here
        mAnimation.Play("attack", PlayMode.StopAll);
    }

}
