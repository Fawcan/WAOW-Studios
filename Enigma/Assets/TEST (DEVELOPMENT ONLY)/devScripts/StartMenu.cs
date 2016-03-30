using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {

    Text mFlashText;
    private float mFadeSpeed = 1f;

	// Use this for initialization
	void Start ()
    {
        //get the Text component
        mFlashText = GetComponent<Text>();
        //Call coroutine BlinkText on Start
        StartCoroutine(BlinkText());
    }

    void Update()
    {
        if (Input.GetButtonDown("Start"))
        {
            SceneManager.LoadScene(1);
        }
    }

    //function to blink the text 
    public IEnumerator BlinkText()
    {
        //blink it forever. You can set a terminating condition depending upon your requirement
        while (true)
        {
            //set the Text's text to blank
            mFlashText.text = "";
            //display blank text for 0.5 seconds
            yield return new WaitForSeconds(.5f);
            //display “I AM FLASHING TEXT” for the next 0.5 seconds
            mFlashText.text = "Press START to Play!";
            yield return new WaitForSeconds(.5f);
        }
    }
}
