using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
    ** WAOW STUDIOS ** - David Halldin
    CoBaseUnit.cs 
    [DISCLAIMER]
    Script is under development and to be handeld only by given resource until otherwise given OKAY!
    This script handels all base information and values for characters and are to be placed in the world as a GameObject by the name UNIT***
    Sript
*/

[RequireComponent(typeof(Animation))]
[RequireComponent(typeof(Rigidbody))]

public class CoBaseUnit : MonoBehaviour
{
    //Serialized protected variables below
    [SerializeField] protected int mHealth = 10;
    [SerializeField] protected float mSpeed = 2f;
    [SerializeField] protected float mAttackSpeed = 1f;
    [SerializeField] protected float mAttackRange = 10f;
    [SerializeField] protected int mDamage = 3;

    //Protected variables below
    protected Animator mAnimatorPlayer;
    protected Rigidbody mRigidBody;
    Animation mAnimation;
    Rigidbody mRigidbody;

    //Private variables below
    private float mAttackSpeedCounter = 0.0f;

    void Awake()
    {
        //Fetch Nessecary components such as animation rigs and rigidbody components
        //Initialize them in correct order and use void OnEnable() if nessecary.
        mRigidBody = GetComponent<Rigidbody>();
        mAnimation = GetComponent<Animation>();
        mAnimation.Stop();
    }//End void Awake

    protected void PlayAnimation(string mAnimationName)
    {
        mAnimation.Play(mAnimationName, PlayMode.StopAll);

    }//End Function PlayAnimation()

    public virtual void Rotate(Quaternion rotation)
    {
        mRigidBody.MoveRotation(rotation);
    }//End Rotate()

    void Update()
    {

    }//End Update()

    public virtual void Die()
    {
        //Do not write here
    }//End Die()

    public virtual void ApplyDamage(int damage)
    {
        //Damage apllied and checks if the player or enemy reaches hp below zero
        //return Die function
    }//End ApplyDamage()

    public virtual void Attack()
    {

    }//End Attack()


}//End CoBaseUnit : MonoBehaviour
