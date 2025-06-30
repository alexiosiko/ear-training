using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
	[SerializeField] TrembleCleff[] trembleCleffs;
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Backspace))
		{
			foreach (var t in trembleCleffs)
				t.RemoveLastNote();	
		}
    }
}
