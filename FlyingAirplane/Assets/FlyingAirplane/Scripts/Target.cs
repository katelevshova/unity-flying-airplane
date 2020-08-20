using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Target start");
        InputController.onDrag += DragTarget; 
    }

    public void DragTarget()
    {
        Debug.Log("->DragTarget");
    }

    private void OnDisable()
    {
        InputController.onDrag -= DragTarget;
    }
}
