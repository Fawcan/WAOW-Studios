using UnityEngine;
using System.Collections;
/*

    // !!! DO NOT OPEN THIS SCRIPT !!!

    *** DISCLAIMER ***
    This script handels all base information and values for characters and are to be placed in the world as a GameObject by the name UNIT
    Script to be handeld by given resource until otherwise

    Notes:
    Commented out line 66. Se below for further information. / Maria

*/
[RequireComponent(typeof(Rigidbody))]
public class BaseUnit : MonoBehaviour
{
    [SerializeField] protected int mHealth = 100; 
    [SerializeField] protected float mSpeed = 2;
    [SerializeField] protected float mAttackSpeed = 1;
    [SerializeField] protected float mAttackRange = 10f;
    [SerializeField] public int mDamage = 10;
    [SerializeField] protected AnimationClip Attacking;     // Added by Maria 10/3 22:45
    
    [SerializeField] protected Animator mAnimatorPlayer;     // Added by Maria 10/3 22:45
    Animation mAnimation;
    protected Rigidbody mRigidBody;
    public bool mNotDead = true;
    public GameObject mPlayer;
    public GameObject mEnemy;    

    private float mAttackSpeedCounter = 0.0f;

    void Awake()
    {
        mAnimation = GetComponent<Animation>();
        mRigidBody = GetComponent<Rigidbody>();
        mPlayer = GameObject.FindGameObjectWithTag("Player");
        mEnemy = GameObject.FindGameObjectWithTag("Enemy");
    }
        
    protected void PlayAnimation(string animationName)
    {
        mAnimation.Play(animationName, PlayMode.StopAll);
        
    }

    public virtual void Rotate(Quaternion rotation)
    {
        mRigidBody.MoveRotation(rotation);
        //Vector3 mRotation = transform.rotation.eulerAngles;

    }
    
    void Update()
    {    
        Vector3 forward = transform.forward;
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), forward, Color.red); 
    }

    public virtual void Die()
    {
        //Do not write here       
    }

    public virtual void ApplyDamage(int mDamage)
    {
        mHealth -= mDamage;

        if (mHealth <= 0 && mNotDead)
        {
            mNotDead = false;
            Die();                       
        }
    }

    public virtual void Attack(BaseUnit target)
    {
        // ("Attacking", true);//player
		mAttackSpeedCounter += Time.deltaTime;//cooldown      
        target.ApplyDamage(mDamage);
        mAttackSpeedCounter = 0.0f;

        //mAnimator.SetBool("Attacking", true);   // Added by Maria 10/3 22:45
        //mAnimation.Play("attack", PlayMode.StopAll);  *** This code is used only for 'Legacy' animations and is NOT compatible with the Player Character Animations! - Maria ***

    }

}
