using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//[RequireComponent(typeof(BoxCollider2D))]   // for working OnMouse either add BoxCollider2D or add IPointerDownHandler
public class GameController : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler
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

        //NOTE: we marked MouseLocation whatIsGround as TargetLayer


        //Find the distance between the mouse and the player
        //float distance = Vector3.Distance(MouseLocation.Instance.MousePosition, target.transform.position);
        //Debug.Log("distance=" + distance);

        OnDragTarget?.Invoke(target);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        OnEndDragTarget?.Invoke();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnMouseDownTarget?.Invoke();
    }
}
