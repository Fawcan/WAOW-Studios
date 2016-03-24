using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    public Transform destination;
    public Transform mPlayer;
    private Vector3 mHome;
    private Vector3 mCurrentDestination;
    private Animation mAnimation;
    [SerializeField] float mTurnSpeed = 100f;
    [SerializeField] float mDetectionRange = 4.0f;
    private Enemy mEnemy;

    //protected Animator mAnimatorEnemy;

    void Awake()
    {
        mEnemy = GetComponent<Enemy>();
        mPlayer = GameObject.FindGameObjectWithTag("Player").transform;        
        mAnimation = GetComponent<Animation>();
        mHome = transform.position;
        mAnimation.Play("waitingforbattle", PlayMode.StopAll);
        if (mPlayer == null)
            Debug.Log("Cant find player");
    }

    void LateUpdate()
    {
        
    }

    void Update()
    {

        //Debug.Log("Name of player: " + mPlayer.position);
        
        if (mEnemy.mNotDead == false)
        {
            return;
        }
        if (Vector3.Distance(transform.position, mPlayer.position) < mDetectionRange)
        {
            mCurrentDestination = mPlayer.position;
        }
        else
        {
            mCurrentDestination = mHome;
        }

        Vector3 dir = mPlayer.position - transform.position;
        dir = transform.InverseTransformDirection(dir);
        float angle = Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg;
        //Debug.Log(angle);

        if (Vector3.Distance(transform.position, mCurrentDestination) < 2.0f && angle >= 65 && angle <= 115)
        {
            //mEnemy.transform.LookAt(mPlayer, transform.up);
            if (mCurrentDestination == mPlayer.position)
            {
                mEnemy.Attack(mPlayer.GetComponent<BaseUnit>());             
                
            }
            

        }
        else if (mCurrentDestination == mHome && Vector3.Distance(transform.position, mCurrentDestination) < 0.03f)
        {
            //Idle
            mAnimation.Play("waitingforbattle", PlayMode.StopAll);
            Debug.Log("IS home");
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
