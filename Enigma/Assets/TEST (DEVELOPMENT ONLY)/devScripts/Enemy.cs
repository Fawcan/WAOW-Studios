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
        Debug.Log("Enemy Triggered Attack!");

        RaycastHit mHit;
        Vector3 forward = transform.forward * 2f;
        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z), forward, out mHit, 2f) && mHit.transform.tag == "Player")
        {
            Debug.Log("Enemy träff!");
            BaseUnit player = mHit.transform.GetComponent<BaseUnit>();
            if (player == null)
                Debug.LogError("Couldnt find the BaseUnit component");
            //this.Attack(player);
            base.Attack(mTarget);
        } 
        
        mTarget = null;
    }

    void Update()
    {
        if(mHealth <= 0)
        {
            Debug.Log("The health reached: " + mHealth);
            base.PlayAnimation("die");
            Die();
        }
        
    }
    
    public override void Rotate(Quaternion rotation)
    {
        base.Rotate(rotation);
    }

    public override void Die()
    {
        base.Die();
        mNotDead = false;        
        Destroy(gameObject);
    }

}
