using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Vector3 _screenPoint;
    private Vector3 _offset;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("[Target] start");
        GameController.OnMouseDownTarget += OnMouseDownTargetHandler;
        GameController.OnDragTarget += OnDragTargetHandler;
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
