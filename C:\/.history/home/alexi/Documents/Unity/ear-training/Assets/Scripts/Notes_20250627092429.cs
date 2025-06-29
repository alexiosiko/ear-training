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
		Transform nodetransform.GetChild(transform.childCount - 1);
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
