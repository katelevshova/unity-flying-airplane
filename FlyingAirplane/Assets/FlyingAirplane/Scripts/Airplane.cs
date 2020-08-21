using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airplane : MonoBehaviour
{
    public float rotationSpeed = 140f;
    public float speed = 1f;
    public float delay = 1;
    private bool isNotDraggingMode = true;

    void Start()
    {
        Debug.Log("Airplane start");
        GameController.OnDragTarget += FlyTowards;
        GameController.OnEndDragTarget += FreeFlying; 
    }

    private void FreeFlying()
    {
        isNotDraggingMode = true;
    }

    private void FlyTowards(Target target)
    {
        isNotDraggingMode = false;

        Vector3 directionToFace = (target.transform.position - transform.position).normalized;
        var dotProd = Vector3.Dot(transform.right, directionToFace);

        transform.rotation *= Quaternion.AngleAxis(dotProd * rotationSpeed * Time.deltaTime, Vector3.up);

        transform.position += transform.forward * speed * Time.deltaTime * Mathf.Abs(1 - dotProd);
    }

    public void Update()
    {
        if (isNotDraggingMode)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }

    private void OnDisable()
    {
        GameController.OnDragTarget -= FlyTowards;
        GameController.OnEndDragTarget -= FreeFlying;
    }
}
