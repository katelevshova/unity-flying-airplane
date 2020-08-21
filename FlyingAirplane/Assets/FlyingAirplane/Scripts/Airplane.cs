using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airplane : MonoBehaviour
{
    public float rotationSpeed = 90f;
    public float speed = 10f;
    public GameObject target;
    private bool isNotDraggingMode = true;

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
        isNotDraggingMode = false;
        FlyTowards();
    }

    private void FlyTowards()
    {
        Vector3 directionToFace = (target.transform.position - transform.position).normalized;
        var dotProd = Vector3.Dot(transform.right, directionToFace);

        transform.rotation *= Quaternion.AngleAxis(dotProd * rotationSpeed * Time.deltaTime, Vector3.up);

        transform.position += transform.forward * speed * Time.deltaTime * Mathf.Abs(1 - dotProd);
    }

    public void Update()
    {
        if (isNotDraggingMode)
        {
            FlyTowards();
        }
    }

    private void UpdateFlyingMode()
    {
        Debug.Log("EndDrag");
        isNotDraggingMode = true;
    }

    private void OnDisable()
    {
        InputController.OnDragTarget -= FollowTarget;
        InputController.OnEndDragTarget -= UpdateFlyingMode;
    }
}
