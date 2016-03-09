using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Animation))]

public class Player : BaseUnit
{
    [SerializeField]
    CharacterInputManager Input;
    // Use this for initialization
    public virtual void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public override void Die()
    {
        base.Die();
    }


    public void GetInput(Vector2 input)
    {
        //if (input.x > 0)
            //go up
        

    }
}
