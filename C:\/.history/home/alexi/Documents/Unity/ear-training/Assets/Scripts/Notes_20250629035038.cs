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
		switch (note)
		{
			case "C4": 	return 1;
			case "C#4": return 1;
			case "D4": 	return 8;
			case "D#4": return 8;
			case "E4": 	return 9;
			case "F4": 	return 10;
			case "F#4": return 10;
			case "G4": 	return 11;
			case "G#4": return 11;
			case "A4": 	return 12;
			case "A#4": return 12;
			case "B4": 	return 13;
			case "C5": 	return 14;
			case "C#5": return 14;
			case "D5": 	return 15;
			case "D#5": return 10;
			case "E5": 	return 10;
			case "F5": 	return 10;
			case "F#5": return 10;
			case "G5": 	return 10;
			case "G#5": return 10;
			case "A5": 	return 10;
			case "A#5": return 10;
			case "B5": 	return 1	0;
		}
		return -1;
	}
}
