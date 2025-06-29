using UnityEngine;

public class Notes : MonoBehaviour
{
	[SerializeField] Transform noteObject	;
	public void AddNote(string note)
	{
		Transform newNote = Instantiate(noteObject, Vector3.zero, Quaternion.identity, transform);
		Vector2 pos = new Vector2(transform.childCount, 0);
		newNote.localPosition = pos;
	}
	public void RemoveLastNote()
	{
		Debug.Log("HerE");
		if (transform.childCount == 0)
			return;
		Transform note = transform.GetChild(transform.childCount - 1);
		Destroy(note.gameObject);
	}
	void FormatNotes()
	{

	}
	public static Notes Singleton;
	void Awake()
	{
		Singleton = this;
	}


	int NoteNameToChildPosition(string  note)
	{
		switch 
		return -1;
	}
}
