using UnityEngine;
using System.Collections;

public class EnemyAttacksPlayer : BaseUnit
{
    Animation mAnimation;
    Rigidbody mRigidBody;
	void Awake()
    {
        //Egen init för awake.
        //mAnimation = GetComponent<Animation>();
        //mRigidBody = GetComponent<Rigidbody>();
    }
	void Start ()
    {
        BaseUnit.Move();
    }

    public override void Move(Vector2 direction)
    {
        base.Move(direction);
        //eget state
    }

    public override void Attack()
    {
        base.Attack();
    }


    // Update is called once per frame
    void Update ()
    {
	
	}
}
