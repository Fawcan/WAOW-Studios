using UnityEngine;
using System.Collections;

public class REMOVE_testNavMovement : MonoBehaviour
{

    public Transform targetClick;

    private NavMeshAgent agent;
    private Vector3 position;

    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        position = transform.position;
    }

    /*void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();

        agent.SetDestination(targetClick.position);
    }*/


    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            LocatePosition();
        }

        MoveToPosition();

    }
    void LocatePosition()
    {
        agent.SetDestination(targetClick.position);
    }

    void MoveToPosition()
    {

    }

}