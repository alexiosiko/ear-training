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
		Transform note = transform.GetChild(transform.childCount - 1);
		Destroy(note);
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
