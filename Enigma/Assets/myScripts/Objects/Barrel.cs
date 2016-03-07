using UnityEngine;
using System.Collections;

public class Barrel : MonoBehaviour
{
    public Sprite dmgSprite;
    public int hp = 1;

    private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Awake ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
	
	}
	
    public void DamageBarrel (int loss)
    {
        spriteRenderer.sprite = dmgSprite;
        hp -= loss;
        if (hp <=0)
        {
            gameObject.SetActive(false);
        }
    }
}
