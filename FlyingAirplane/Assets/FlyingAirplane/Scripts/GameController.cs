using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameController : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public delegate void ActionDrag(Target target);
    public delegate void ActionEndDrag();
    public static event ActionDrag OnDragTarget;
    public static event ActionEndDrag OnEndDragTarget;
    public Target target;
    public Airplane airplane;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("InputController start");
    }

    public void OnDrag(PointerEventData eventData)
    {
        OnDragTarget?.Invoke(target);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        OnEndDragTarget?.Invoke();
    }
}
