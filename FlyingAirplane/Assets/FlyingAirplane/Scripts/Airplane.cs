using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Airplane : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 140f;
    [SerializeField]
    private float speed = 1f;
    private bool _isStart = true;
    private Target target;
    // IS a trigger

    private void Awake()
    {
        Debug.Log("[Airplane] Awake");
    }

    void Start()
    {
        Debug.Log("[Airplane] Start");
        GameController.OnDragTarget += FlyTowards;
        GameController.OnEndDragTarget += FreeFlying; 
        target = GameController.Instance.target;
    }
    
    private void FreeFlying()
    {
        
    }
    private void FlyTowards(Target target)
    {
        _isStart = false;
    } 

    public void Update()
    {
        if (_isStart)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        else
        {
            Vector3 directionToFace = (target.transform.position - transform.position).normalized;
            float dotProd = Vector3.Dot(transform.right, directionToFace);

            transform.rotation *= Quaternion.AngleAxis(dotProd * rotationSpeed * Time.deltaTime, Vector3.up);

            transform.position += transform.forward * speed * Time.deltaTime * Mathf.Abs(1 - dotProd);

            /*
            float step = speed * Time.deltaTime ; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, GameController.Instance.target.transform.position, step);
            */
        }
    }

    private void OnDisable()
    {
        GameController.OnDragTarget -= FlyTowards;
        GameController.OnEndDragTarget -= FreeFlying;
    }
}
