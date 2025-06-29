using UnityEngine;

public class Notes : MonoBehaviour
{
	public void AddNote(string note)
	{

	}
	public void RemoveLastNote()
	{
		if (transform.childCount == 0)
			return;
		trasfnrom
	}
	void FormatNotes()
	{

	}
	public static Notes Singleton;
	void Awake()
	{
		Singleton = this;
	}
}
