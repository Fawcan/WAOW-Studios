using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    public Transform destination;
    public Transform mPlayer;
    private Vector3 mHome;
    private Vector3 mCurrentDestination;
    float mTurnSpeed = 100f;
    [SerializeField]
    float mDetectionRange = 4.0f;
    private Enemy mEnemy;

    //protected Animator mAnimatorEnemy;

    void Awake()
    {
        mEnemy = GetComponent<Enemy>();
        mPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        mHome = transform.position;
        if (mPlayer == null)
            Debug.Log("Cant find player");
    }

    void LateUpdate()
    {
        
    }

    void Update()
    {
        
        //Debug.Log("Name of player: " + mPlayer.position);
        if (Vector3.Distance(transform.position, mPlayer.position) < mDetectionRange)
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
                mEnemy.Attack(mPlayer.GetComponent<BaseUnit>());
            }
            else if(mCurrentDestination == mHome)
            {
                //Idle
            }

        }
        else
        {
            ////Rotate
            //Vector3 targetDir = mCurrentDestination - transform.position;
            //float step = mTurnSpeed * Time.deltaTime;
            //Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
            //mEnemy.Rotate(Quaternion.LookRotation(newDir));
            //Move
            mEnemy.Move(mCurrentDestination);
            
        }


    }

}
