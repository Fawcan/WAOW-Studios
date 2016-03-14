using UnityEngine;
using System.Collections;

public class afMovement : MonoBehaviour
{
    [SerializeField]
    GameObject mPlayer;
    Vector3 targetPosition;
    float mSpeed = 3;
    public CharacterController controller;

    void Start()
    {

        targetPosition = transform.position;
    }
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                targetPosition = hit.point;
                mPlayer.transform.position = targetPosition;
                controller.SimpleMove(transform.forward * mSpeed);

            }
        }
    }
}