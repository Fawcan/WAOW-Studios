﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class UserInterface : Player
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
    private GameObject mHealthBar;
    public int mCurrentHealth;
    Image mHealthBarFull;
    private bool mHasHealth = true;
    private int mHPloss;
       

    
	// Use this for initialization
	void Start()
    {
        mHealthBarFull = GameObject.FindGameObjectWithTag("Canvas").transform.FindChild("HealthFull").GetComponent<Image>();

    }//End Awake()

    // Update is called once per frame
    void Update()
    {

        //mHealthBarFull.fillAmount = mHealth--;
        //mHealthBar.transform.localScale = new Vector3(Mathf.Clamp(mHealth, 0f, 1f), mHealthBar.transform.localScale.y, mHealthBar.transform.localScale.z);

    }//End Update()

    ////This function is called by the 'testHealthBar' Script.
    //public void SetHealthBar(float mHealth)
    //{
    //    mHealthBar.transform.localScale = new Vector3(Mathf.Clamp(mHealth, 0f, 1f), mHealthBar.transform.localScale.y, mHealthBar.transform.localScale.z);
    //}//End SetHealthBar

    public void SetHealthBar(float mHealth)
    {
        mHealthBar.transform.localScale = new Vector3(Mathf.Clamp(mHealth, 0f, 1f), mHealthBar.transform.localScale.y, mHealthBar.transform.localScale.z);
    }

    public void DecreaseHealth()
    {
        if(mHasHealth)
        {
            mHPloss = mHealth - mDamage;
            mHealthBarFull.fillAmount = mHealth;
        }
    }
}

