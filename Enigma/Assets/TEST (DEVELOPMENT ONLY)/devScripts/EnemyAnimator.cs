using UnityEngine;
using System.Collections;

public class EnemyAnimator : MonoBehaviour {
    
    /*
    Script by Maria

    *** READ THIS FIRST ***

    Add the Animator controller in the inspector of the skeleton
    and make sure that 'EnemyAnimator' is in the controller-
    field and the 'skeletonAvatar' is in the avatar-field.
    Place the following lines below under the Enemy's
    corresponding states in the Enemy script.

    Note that 'mAnimatorPlayer' will be used for the PLAYER 
    animations and 'mAnimatorEnemy' will be used for ENEMY 
    animations!

    (Animation parameter -setTrigger automaticly resets the animation 
    to false when the animation have finished, unlike the -SetBool
    parameter which you need to reset manually through code.)
    */

    // Add this before void Start()
    //      protected Animator mAnimatorEnemy;


    // In void Start() add this
    //      mAnimatorEnemy = GetComponent<Animator>();


    // Animation parameter for blend between WALKING and IDLE
    //      mAnimatorEnemy.SetFloat("VSpeed", Input.GetAxis("Vertical"));


    // Triggers ATTACK animation
    //      mAnimatorEnemy.SetTrigger("Attacking");


    // Bool for DEATH animation
    //      mAnimatorPlayer.SetBool("Die", true);
    // Before player respawn set bool to false:
    //      mAnimatorPlayer.SetBool("Die", false);

}
