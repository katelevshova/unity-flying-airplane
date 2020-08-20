using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airplane : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Airplane start");
        InputController.onDrag += FollowTarget;
    }

    public void FollowTarget()
    {
        Debug.Log("->FollowTarget");
    }

    private void OnDisable()
    {
        InputController.onDrag -= FollowTarget;
    }
}
