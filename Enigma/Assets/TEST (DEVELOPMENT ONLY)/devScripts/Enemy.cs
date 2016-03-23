using UnityEngine;
using System.Collections;

/*
    Add description - Dont write in this script until otherwise given OKAY

*/


public class Enemy : BaseUnit
{
    [SerializeField]
    protected NavMeshAgent agent;

    private BaseUnit mTarget;
    
    public void Move(Vector3 destination)
    {
        base.PlayAnimation("run");
        agent = gameObject.GetComponent<NavMeshAgent>();
        agent.SetDestination(destination);
    }

    public override void Attack(BaseUnit target)
    {
        if (target.GetComponent<Player>().mNotDead)
        {
            mTarget = target;
            base.PlayAnimation("attack");
            //Debug.Log(mHealth);

        }       

    }

    public void TriggerAttack()
    {
        base.Attack(mTarget);
        mTarget = null;
    }
    
    public override void Rotate(Quaternion rotation)
    {
        base.Rotate(rotation);
    }

    public override void Die()
    {
        base.PlayAnimation("die");
        base.mNotDead = false;
        //Destroy(gameObject);
        base.Die();


    }

}
