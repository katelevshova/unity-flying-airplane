using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour, IDragHandler
{
    public delegate void ActionDrag();
    public static event ActionDrag onDrag;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("InputController start");
    }

    public void OnDrag(PointerEventData eventData)
    {
        onDrag?.Invoke();
    }
}
