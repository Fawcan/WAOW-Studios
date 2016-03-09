using UnityEngine;
using System.Collections;

public class Player : BaseUnit
{
    [SerializeField]
    CharacterInputManager Input;
    // Use this for initialization
    public virtual void Start()
    {
        //base.start();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void GetInput(Vector2 input)
    {
        //if (input.x > 0)
            //go up

    }
}
