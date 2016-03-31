using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ControllerLayout : MonoBehaviour {

    /*
    Script by Maria

    This script is used for the Controller Layout only.
    It will controll for how long ControllerLayout Scene
    will show and after the delay it will load FirstLevel.
    */

	// Use this for initialization
	void Start ()
    {
	    StartCoroutine(StartDelay());
        Debug.Log("Delay started.");
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(5f);
        Debug.Log("Delay done.");
        SceneManager.LoadScene(2);

    }
}
