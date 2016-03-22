using UnityEngine;
using System.Collections;

public class Barrel : MonoBehaviour
{
    
    [SerializeField]
    public int mHp = 1;        //hit points for the barrel.

   
    //DamageBarrel is called when the player attacks a barrel.
    public void DamageBarrel (int loss)
    {
        
        //Subtract loss from hit point total.
        mHp -= loss;
        //If hit points are less than or equal to zero:
        if (mHp <=0)
        {
            //Disable the gameObject.
            Destroy(gameObject);
        }
    }
}
