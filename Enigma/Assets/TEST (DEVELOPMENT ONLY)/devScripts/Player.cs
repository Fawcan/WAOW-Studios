using UnityEngine;
using System.Collections;


//[RequireComponent(typeof(Animation))]

public class Player : BaseUnit
{
    private float mInteractDist; // for debug purposue
    public virtual void Start()
    {
        
    }

    public void Move(Vector2 direction)
    {
        //base.PlayAnimation("run");
        Vector3 mMovement = new Vector3();
        mMovement.Set(direction.x, 0f, direction.y);
        mMovement = mMovement.normalized * mSpeed * Time.deltaTime;
        mRigidBody.MovePosition(transform.position + mMovement);
    }


    void Update()
    {
        Vector3 mRayOrigin = transform.position + new Vector3(0, 1, 0);

        Ray ray = new Ray(mRayOrigin, transform.forward);

        Debug.DrawRay(mRayOrigin, transform.forward * mInteractDist, Color.green);
    }
    public override void Attack(BaseUnit target)
    {
            base.Attack(target);
    }

    public override void Rotate(Quaternion rotation)
    {
        base.Rotate(rotation);
    }



}
