using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Backspace))
		{
			Notes.Singleton.delete
		}
    }
}
