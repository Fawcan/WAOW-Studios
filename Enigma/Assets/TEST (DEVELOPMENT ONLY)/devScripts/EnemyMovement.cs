using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    public Transform destination;
  
    private Transform mPlayer;
    private Vector3 mHome;
    private Vector3 mCurrentDestination;

    float mTurnSpeed = 100f;

    float mDetectionRange = 10.0f;

    private Enemy mEnemy;

   
   

    void Awake()
    {
        mEnemy = GetComponent<Enemy>();

        mPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        mHome = transform.position;

    }

    void Update()
    {

        if (Vector3.Distance(transform.position, mPlayer.transform.position) < mDetectionRange)
        {
            mCurrentDestination = mPlayer.position;
        }
        else
        {
            mCurrentDestination = mHome;
        }

        if(Vector3.Distance(transform.position, mCurrentDestination) < 2.0f)
        {
 
            if (mCurrentDestination == mPlayer.position)
            {
                //Attack
                SceneManager.LoadScene(2);

            }
            else if(mCurrentDestination == mHome)
            {
                //Idle
            }

        }
        else
        {
            //Rotate
            Vector3 targetDir = mCurrentDestination - transform.position;
            float step = mTurnSpeed * Time.deltaTime;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
            mEnemy.Rotate(Quaternion.LookRotation(newDir));
            //Move
            mEnemy.Move(mCurrentDestination);

        }


    }

}
