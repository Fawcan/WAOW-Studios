using UnityEngine;
using System.Collections;
/*
    *** DISCLAIMER ***
    This script handels all base information and values for characters and are to be placed in the world as a GameObject by the name UNIT
    Script to be handeld by given resource until otherwise
*/
public class baseUnit : MonoBehaviour
{
    int mHealth;
    float mMovementSpeed;
    float mAttackSpeed;
    float mAttackRange;
    int mEnergy;
    int mDamage;
    

    void Start()
    {
        //write init variables here
    }

    void Update()
    {
       //do not write code here
    }

    public virtual void Move(Vector2 direction)
    {
        //input here
    }

    public virtual void Rotate(float angle)
    {

    }

    public virtual void Attack()
    {
        //Attack input and events here
    }

}
