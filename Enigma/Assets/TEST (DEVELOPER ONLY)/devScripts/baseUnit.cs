using UnityEngine;
using System.Collections;
/*

    // !!! DO NOT OPEN THIS SCRIPT !!!

    *** DISCLAIMER ***
    This script handels all base information and values for characters and are to be placed in the world as a GameObject by the name UNIT
    Script to be handeld by given resource until otherwise

*/
public class baseUnit : MonoBehaviour
{
    [SerializeField]
    int mHealth;
    [SerializeField]
    float mSpeed;
    [SerializeField]
    float mAttackSpeed;
    [SerializeField]
    float mAttackRange;
    [SerializeField]
    int mDamage;
    // [SerializeField]
    // int mEnergy;

    void Start()
    {
        mHealth = 10;
        mSpeed = 2;
        mAttackSpeed = 1;
        mAttackRange = 10;
        mDamage = 3;

    }

    void Update()
    {


    }

    //virtual void Move(Vector2 direction)
    //{


    //}

    //virtual Rotate()
    //{


    //}

    //virtual Attack()
    //{


    //}

}
