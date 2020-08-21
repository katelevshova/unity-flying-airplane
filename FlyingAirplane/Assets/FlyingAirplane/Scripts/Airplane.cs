using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airplane : MonoBehaviour
{
    public float rotationSpeed = 90f;
    public float speed = 10f;
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

        Vector3 directionToFace = (target.transform.position - transform.position).normalized;
        Debug.DrawRay(transform.position, directionToFace, Color.green);
        transform.rotation = Quaternion.LookRotation(directionToFace);


    }

    public void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void UpdateFlyingMode()
    {
        Debug.Log("EndDrag");
    }

    private void OnDisable()
    {
        InputController.OnDragTarget -= FollowTarget;
        InputController.OnEndDragTarget -= UpdateFlyingMode;
    }
}
