using UnityEngine;
using System.Collections;

public class Barrel : MonoBehaviour
{
    [SerializeField]
    Sprite dmgSprite;   //Alternate sprite to display after barrel has been attacked by player.
    [SerializeField]
    int mHp = 1;        //hit points for the barrel.

    private SpriteRenderer spriteRenderer;  //Store a component reference to the attached SpriteRenderer.


    void Awake ()
    {
        //Get a component reference to the SpriteRenderer.
        spriteRenderer = GetComponent<SpriteRenderer>();
	
	}

    //DamageBarrel is called when the player attacks a barrel.
    public void DamageBarrel (int loss)
    {
        //Set spriteRenderer to the damaged barrel sprite.
        spriteRenderer.sprite = dmgSprite;
        //Subtract loss from hit point total.
        mHp -= loss;
        //If hit points are less than or equal to zero:
        if (mHp <=0)
        {
            //Disable the gameObject.
            gameObject.SetActive(false);
        }
    }
}
