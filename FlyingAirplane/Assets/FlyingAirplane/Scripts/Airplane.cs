using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airplane : MonoBehaviour
{
    public float rotationSpeed = 90f;
    public float speed = 10f;
    private bool isNormalMode = true;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Airplane start");
        InputController.OnDragTarget += FollowTarget;
        InputController.OnEndDragTarget += UpdateFlyingMode;
    }

    public void FollowTarget(Vector3 targetPosition)
    {
        Debug.Log("->FollowTarget "+ targetPosition);
        isNormalMode = false;

        Vector3 directionToFace = (target.transform.position - transform.position).normalized;
        Debug.DrawRay(transform.position, directionToFace, Color.green);
        transform.rotation = Quaternion.LookRotation(directionToFace);


        transform.position += transform.forward * speed * Time.deltaTime ;
    }

    public void Update()
    {
        if (isNormalMode)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }

    private void UpdateFlyingMode()
    {
        isNormalMode = true;
    }

    private void OnDisable()
    {
        InputController.OnDragTarget -= FollowTarget;
    }
}
