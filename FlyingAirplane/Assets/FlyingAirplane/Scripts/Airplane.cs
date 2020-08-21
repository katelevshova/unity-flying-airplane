using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airplane : MonoBehaviour
{
    public float rotationSpeed = 140f;
    public float speed = 1f;
    private Target _target;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Airplane start");
    }

    public void SetTarget(Target target)
    {
        _target = target;
    }

    private void FlyTowards()
    {
        Vector3 directionToFace = (_target.transform.position - transform.position).normalized;
        var dotProd = Vector3.Dot(transform.right, directionToFace);

        transform.rotation *= Quaternion.AngleAxis(dotProd * rotationSpeed * Time.deltaTime, Vector3.up);

        transform.position += transform.forward * speed * Time.deltaTime * Mathf.Abs(1 - dotProd);
    }

    public void Update()
    {
        FlyTowards();
    }
}
