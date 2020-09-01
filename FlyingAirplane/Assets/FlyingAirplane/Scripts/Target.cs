using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody))]
public class Target : MonoBehaviour
{
    private Vector3 _screenPoint;
    private Vector3 _offset;

    private void Awake()
    {
        Debug.Log("[Target] Awake");
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("[Target] Start");
        GameController.OnMouseDownTarget += OnMouseDownTargetHandler;
        GameController.OnDragTarget += OnDragTargetHandler;
    }

    private void Update()
    {
        
        transform.Rotate(0f, 25f * Time.deltaTime, 0f);
        //transform.position += transform.forward * 2f * Time.deltaTime ; //transform.Translate(2f * Time.deltaTime, 0f, 0f); // doesn't have direction
    }

    private void OnMouseDownTargetHandler()
    {
        Debug.Log("[Target]->OnMouseDownTargetHandler");
        _screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        _offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z));
    }

    public void OnDragTargetHandler(Target target)
    {
        Debug.Log("[Target]->OnDragTargetHandler");

        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + _offset;
        transform.position = curPosition;
    }

    private void OnDisable()
    {
        GameController.OnDragTarget -= OnDragTargetHandler;
        GameController.OnMouseDownTarget -= OnMouseDownTargetHandler;
    }
}
