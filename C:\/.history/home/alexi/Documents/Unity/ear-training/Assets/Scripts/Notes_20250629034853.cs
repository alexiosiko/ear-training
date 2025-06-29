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
			case "C3": 	return 0;
			case "C#3":	return 0;
			case "D3": 	return 1;
			case "D#3": return 1;
			case "E3": 	return 2;
			case "F3": 	return 3;
			case "F#3": return 3;
			case "G3": 	return 4;
			case "G#3": return 4;
			case "A3": 	return 5;
			case "A#3": return ;
			case "B3": 	return 0;
			case "C4": 	return 0;
			case "C#4": return 0;
			case "D4": 	return 0;
			case "D#4": return 0;
			case "E4": 	return 0;
			case "F4": 	return 0;
			case "F#4": return 0;
			case "G4": 	return 0;
			case "G#4": return 0;
			case "A4": 	return 0;
			case "A#4": return 0;
			case "B4": 	return 0;
			case "C5": 	return 0;
			case "C#5": return 0;
			case "D5": 	return 0;
			case "D#5": return 0;
			case "E5": 	return 0;
			case "F5": 	return 0;
			case "F#5": return 0;
			case "G5": 	return 0;
			case "G#5": return 0;
			case "A5": 	return 0;
			case "A#5": return 0;
			case "B5": 	return 0;
		}
		return -1;
	}
}
