using UnityEngine;
using System.Collections;

/*
    Add description - Dont write in this script until otherwise given OKAY

*/


public class Enemy : BaseUnit
{
    private NavMeshAgent agent;
    private Animator mAnimatorEnemy;

    void Start()
    {
        mAnimatorEnemy = GetComponent<Animator>();
    }

    void Update()
    {
        mAnimatorEnemy.SetFloat("EVSpeed", Input.GetAxis("Vertical"));
    }


    public void Move(Vector3 destination)
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        agent.SetDestination(destination);
    }

    public override void Attack(BaseUnit target)
    {
        base.Attack(target);
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
