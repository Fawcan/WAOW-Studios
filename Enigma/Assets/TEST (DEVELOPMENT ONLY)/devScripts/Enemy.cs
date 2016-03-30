using UnityEngine;
using System.Collections;

/*
    Add description - Dont write in this script until otherwise given OKAY

*/


public class Enemy : BaseUnit
{
    [SerializeField]
    protected NavMeshAgent agent;
    [SerializeField]
    protected AnimationClip die;


    private BaseUnit mTarget;

    private bool inCombat = false;
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

    private bool mTriggeredDead = false;
    void Update()
    {

        if (Health <= 0 && !mTriggeredDead)
        {
            mTriggeredDead = true;
            Debug.Log("The health reached: " + Health);

            //mNotDead = false;
            Die();
        }



    }

    public override void Rotate(Quaternion rotation)
    {
        base.Rotate(rotation);
    }

    public override void Die()
    {
        Debug.Log("Död");
        //base.PlayAnimation("die", PlayMode.StopAll);
        //mAnimation.Play(animationName, PlayMode.StopAll);
        base.PlayAnimation("die");
        mNotDead = false;
        base.Die();
      
                
       // Destroy(gameObject);
    }

}
