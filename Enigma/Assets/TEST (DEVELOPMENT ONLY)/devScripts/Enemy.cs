using UnityEngine;
using System.Collections;

public class Enemy : BaseUnit
{
    [SerializeField]
    protected int mEnemyHP = 10;
    [SerializeField]
    protected float mEnemySpeed = 2f;
    [SerializeField]
    protected float mEnemyAttackSpeed = 1f;
    [SerializeField]
    protected float mEnemyAttackRange = 10f;
    [SerializeField]
    protected int mEnemyDamage = 2;

    void Awake()
    {
        GetComponent<Animation>();
        GetComponent<Rigidbody>();
    }

    public override void Move(Vector2 direction)
    {
        base.Move(direction);
    }

    public override void Attack()
    {
        base.Attack();

    }

    public override void Rotate(Quaternion rotation)
    {
        base.Rotate(rotation);
    }

    public override void Die()
    {
        base.Die();
    }

}
