using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(BoxCollider2D))]   // for working OnMouse
public class GameController : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public delegate void ActionDrag(Target target);
    public delegate void ActionEndDrag();
    public delegate void ActionMouseDown();
    public static event ActionDrag OnDragTarget;
    public static event ActionEndDrag OnEndDragTarget;
    public static event ActionMouseDown OnMouseDownTarget;
    public Target target;
    public Airplane airplane;


    void Start()
    {
        Debug.Log("[GameController] start");
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag");

        //If we don't have a MouseLocation script in the scene or if the position of the mouse isn't valid, leave Update()
        if (MouseLocation.Instance == null || !MouseLocation.Instance.IsValid)
            return;

        //NOTE: we marked  MouseLocation whatIsGround as TargetLayer

        OnDragTarget?.Invoke(target);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        OnEndDragTarget?.Invoke();
    }

    void OnMouseDown()
    {
        OnMouseDownTarget?.Invoke();
    }
}
