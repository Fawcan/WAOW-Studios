using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class UserInterface : MonoBehaviour
{

    /*
    Script by Maria

        This script should be used for ALL User interface
        that is connected to the player, for example
        'Healthbar', 'Perk-cooldown' and 'number of potions 
        in stock'.
        Make sure to add game object 'Healthfull' to the 'M
        Health Bar' field in the inspector after adding this
        script to Canvas components.
        
    */

    [SerializeField]
    private Image mHealthBarFull;
    public int mCurrentHealth;
    public int CurrentHealth
    {
        get
        {
            return mCurrentHealth;
        }
        set
        {
            mCurrentHealth = Mathf.Clamp(value, 0, 100);
            mHealthBarFull.fillAmount = mCurrentHealth / 100f;

        }
    }
    
    
	// Use this for initialization
	void Start()
    {
        //mHealthBarFull = GameObject.FindGameObjectWithTag("Canvas").transform.FindChild("HealthFull").GetComponent<Image>();
        //this.CurrentHealth = 5;
    }//End Awake()

    // Update is called once per frame
    void Update()
    {

        //mHealthBar.transform.localScale = new Vector3(Mathf.Clamp(mHealth, 0f, 1f), mHealthBar.transform.localScale.y, mHealthBar.transform.localScale.z);

    }//End Update()

    ////This function is called by the 'testHealthBar' Script.
    //public void SetHealthBar(float mHealth)
    //{
    //    mHealthBar.transform.localScale = new Vector3(Mathf.Clamp(mHealth, 0f, 1f), mHealthBar.transform.localScale.y, mHealthBar.transform.localScale.z);
    //}//End SetHealthBar

    //public void SetHealthBar(float mHealth)
    //{
    //    mHealthBar.transform.localScale = new Vector3(Mathf.Clamp(mHealth, 0f, 1f), mHealthBar.transform.localScale.y, mHealthBar.transform.localScale.z);
    //}
}

