using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

	//Serialized private variables below
    //Public variables below
    //Component constructors below
}
