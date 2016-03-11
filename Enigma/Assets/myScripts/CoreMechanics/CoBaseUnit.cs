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
    [SerializeField] protected int mHealth;
    [SerializeField] protected float mSpeed;
    [SerializeField] protected float mAttackSpeed;
    [SerializeField] protected float mAttackRange;
    [SerializeField] protected int mDamage;

    //Protected variables below
    protected Animator mAnimatorPlayer;
    protected Rigidbody mRigidBody;

    //Private variables below
    private float mAttackSpeedCounter;

    void Awake()
    {
        //Fetch Nessecary components such as animation rigs and rigidbody components
        //Initialize them in correct order and use void OnEnable() if nessecary.
        mRigidBody = GetComponent<Rigidbody>();
    }//End void Awake

    protected void PlayAnimation(string mAnimationName)
    {
        switch(mAnimationName)
        {
            //Changes states of animation
        }

    }//End Function PlayAnimation()

    public virtual void Rotate(Quaternion rotation)
    {
        mRigidBody.MoveRotation(rotation);
    }

    void Update()
    {

    }

    public virtual void ApplyDamage(int damage)
    {

    }


}
