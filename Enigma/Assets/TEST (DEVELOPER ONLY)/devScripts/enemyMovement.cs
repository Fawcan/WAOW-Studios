using UnityEngine;
using System.Collections;

public class enemyMovement : MonoBehaviour
{
    Rigidbody enemyRigidBody;
    public Transform destination;
    private NavMeshAgent agent;
    Rigidbody playerRigidbody;      // Reference to the enemy's rigidbody.
    [SerializeField]
    Transform mPlayer;
    float mTurnSpeed = 100f;

    // Run and idle animation for the enemy character.
    [SerializeField]
    AnimationClip run;
    [SerializeField]
    AnimationClip idle;

    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        GetComponent<Animation>().Play(run.name);   // Running animation


        Vector3 targetDir = mPlayer.position - transform.position;
        float step = mTurnSpeed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
        Debug.DrawRay(transform.position, newDir, Color.red);
        transform.rotation = Quaternion.LookRotation(newDir);
        agent = gameObject.GetComponent<NavMeshAgent>();

        agent.SetDestination(destination.position);
    }

}
