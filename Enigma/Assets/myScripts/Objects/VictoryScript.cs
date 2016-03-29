using UnityEngine;
using System.Collections;

public class VictoryScript : MonoBehaviour
{
    bool BossKilled = false;
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(BossKilled == true)
        {
            Application.LoadLevel("VictoryScene");
        }
	}
}
