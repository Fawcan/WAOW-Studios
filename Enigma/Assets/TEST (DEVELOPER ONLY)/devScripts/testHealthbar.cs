using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class testHealthbar : MonoBehaviour {

    /*
    Script created by Maria.

    This script is used to test Player Healthbar.

    At this moment Healthbar is set to decrease over time
    and should be changed when enemy can inflict damage to 
    player. Note that if it is decided should we use the
    auto-regenerated health the test code could be used
    in order to increase health as well. 
    
    Please make sure NOT to delete anything in this script,
    rather comment code out instead.
    */

    [SerializeField]
    private float mTestMaxHP = 100f;
    [SerializeField]
    private float mTestCurrentHP = 0f;

    // Use this for initialization
    void Start ()
    {
        mTestCurrentHP = mTestMaxHP;
        InvokeRepeating("decreaseHealth", 1f, 1f);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(mTestCurrentHP <= 0)
        {
          SceneManager.LoadScene(1);    
        }
    }

    public void decreaseHealth()
    {
        mTestCurrentHP -= 2f;
        float mCalcHealth = mTestCurrentHP / mTestMaxHP; //Calculation for how much the Healthbar will shrink when HP is reduced.

        //Calls function SetHealthBar from the 'userInterface' Script.
        GameObject.FindGameObjectWithTag("Canvas").GetComponent<userInterface>().SetHealthBar(mCalcHealth);
    }
}
