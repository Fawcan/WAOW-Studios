using UnityEngine;
using System.Collections;

public class PlayerAnimator : MonoBehaviour {

<<<<<<< HEAD
    /*
    Script by Maria

        *** READ THIS FIRST ***

    Add the Animator controller in the inspector of the player
    and make sure that 'PlayerAnimator' is in the controller-
    field and the 'Ganfaul_M_AureAvatar' is in the avatar-field.
    Place the following lines below under the player's
    corresponding states in the Player script.

    Note that 'mAnimatorPlayer' will be used for the PLAYER 
    animations and 'mAnimatorEnemy' will be used for ENEMY 
    animations!

    (Animation parameter -setTrigger automaticly resets the animation 
    to false when the animation have finished, unlike the -SetBool
    parameter which you need to reset manually through code.)
    */


    // Add this before void Start()
    //      protected Animator mAnimatorPlayer;

    // In void Start() add this
    //      mAnimatorPlayer = GetComponent<Animator>();


    // Animation parameter for blend between WALKING and IDLE
    //      mAnimator.SetFloat("VSpeed", Input.GetAxis("Vertical"));

    // Triggers ATTACK animation
    //      mAnimatorPlayer.SetTrigger("Attacking");


    // Bool for DEATH animation
    //      mAnimatorPlayer.SetBool("Die", true);
    // Before player respawn set bool to false:
    //      mAnimatorPlayer.SetBool("Die", false);


    // Triggers TAKE DAMAGE animation
    //      mAnimatorPlayer.SetTrigger("Hit");


=======
    [SerializeField] private Animator mAnimator;

	// Use this for initialization
	void Start ()
    {

        mAnimator = GetComponent<Animator>();
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        // Animation parameter for blend between Walking and Idle
        mAnimator.SetFloat("VSpeed", Input.GetAxis("Vertical"));
        
	
	}
>>>>>>> 8013c22ffae4d319e327100516c1a1d736a1a774
}
