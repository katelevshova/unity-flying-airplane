using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public delegate void ActionDrag(Vector3 targetPosition);
    public delegate void ActionEndDrag();
    public static event ActionDrag OnDragTarget;
    public static event ActionEndDrag OnEndDragTarget;
    public GameObject target;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("InputController start");
    }

    public void OnDrag(PointerEventData eventData)
    {
        OnDragTarget?.Invoke(target.transform.position);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        OnEndDragTarget?.Invoke();
    }
}
