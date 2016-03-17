using UnityEngine;
using System.Collections;

/*
    Add description - Dont write in this script until otherwise given OKAY

*/


public class Enemy : BaseUnit
{
    [SerializeField]
    protected NavMeshAgent agent;
    
    public void Move(Vector3 destination)
    {
        base.PlayAnimation("run");
        agent = gameObject.GetComponent<NavMeshAgent>();
        agent.SetDestination(destination);
    }

    public override void Attack(BaseUnit target)
    {
        base.Attack(target);
        base.PlayAnimation("attack");
        //base.ApplyDamage(mDamage);
        Debug.Log(mHealth);

    }

    public override void Rotate(Quaternion rotation)
    {
        base.Rotate(rotation);
    }

    public override void Die()
    {
      
        Destroy(gameObject);
        base.Die();


    }

}
