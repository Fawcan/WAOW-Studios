using UnityEngine;
using System.Collections;

                                                                    //Kristofer Augustsson. 
// This script makes the enemy attack the player


public class EnemyAttack : MonoBehaviour
{
    public GameObject target;
    [SerializeField]
    public float mAttackTime = 0;
    [SerializeField]
    public float mCoolDown = 2.0f;



    void Start()
    {
        mAttackTime = 0;
        mCoolDown = 2.0f;

    }


    void Update()
    {
        if (mAttackTime > 0)
            mAttackTime -= Time.deltaTime;

        if (mAttackTime < 0)
            mAttackTime = 0;


        if (mAttackTime == 0)
        {
            Attack();
            mAttackTime = mCoolDown;
        }

    }

    private void Attack() 
    {
        float distance = Vector3.Distance(target.transform.position, transform.position); //This check the position ef the target.


        Vector3 dir = (target.transform.position - transform.position).normalized; //This makes the enemy move towards target.
        float direction = Vector3.Dot(dir, transform.forward);


        if (distance < 2.5f) // Checks the distance to target. 
        {
            if (direction > 0)
            {
                PlayerHealth eh = (PlayerHealth)target.GetComponent("PlayerHealth");
                eh.AddjustCurrentHealth(-10);
            }
        }
    }
}