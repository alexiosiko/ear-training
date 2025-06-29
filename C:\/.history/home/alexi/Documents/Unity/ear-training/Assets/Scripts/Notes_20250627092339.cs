using UnityEngine;

public class Notes : MonoBehaviour
{
	public void AddNote(string note)
	{

	}
	public static Notes Singleton;
	void Awake()
	{
		Singleton = this;
	}
}
