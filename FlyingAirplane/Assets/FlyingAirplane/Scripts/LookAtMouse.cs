
using UnityEngine;
public class LookAtMouse : MonoBehaviour
{
	void Update()
	{
		//If the a MouseLocation script is in the scene and its mouse location is valid...
		if (MouseLocation.Instance != null && MouseLocation.Instance.IsValid)
		{
			//Point the Z axis of this game object at it
			transform.LookAt(MouseLocation.Instance.MousePosition);
		}
	}
}