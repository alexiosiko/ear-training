using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Notes : MonoBehaviour
{
	[SerializeField] Transform trembleCleffTransform;
	[SerializeField] GameObject noteObject;
	List<RectTransform> notes = new List<RectTransform>();
	int maxNotes = 5;
	public void AddNote(int childCount)
	{
		// Instantiate under the UI parent (do not set position/rotation)
		GameObject newNoteObj = Instantiate(noteObject, transform);
		RectTransform newNoteRect = newNoteObj.GetComponent<RectTransform>();

		Transform line = trembleCleffTransform.GetChild(childCount);
		newNoteRect.SetParent(line);


		// Get x pos
		float totalWidth = trembleCleffTransform.GetComponent<RectTransform>().rect.width - 200f;
		float gap = totalWidth / maxNotes;
		float x = gap * notes.Count - totalWidth / 2f;

		// Set x pos
		newNoteRect.anchoredPosition = new(x, 0);

		// Store
		notes.Add(newNoteRect);
	}

	public void RemoveLastNote()
	{
		if (notes.Count == 0)
			return;
		Destroy(notes.remove.gameObject);
		notes.RemoveAt(-1);

	}
	void FormatNotes()
	{

	}
	public static Notes Singleton;
	void Awake()
	{
		Singleton = this;
	}


	public static int NoteNameToChildPosition(string  note)
	{
		switch (note)
		{
			case "C4": 	return 1;
			case "C#4": return 1;
			case "D4": 	return 2;
			case "D#4": return 2;
			case "E4": 	return 3;
			case "F4": 	return 4;
			case "F#4": return 4;
			case "G4": 	return 5;
			case "G#4": return 5;
			case "A4": 	return 6;
			case "A#4": return 6;
			case "B4": 	return 7;
			case "C5": 	return 8;
			case "C#5": return 8;
			case "D5": 	return 9;
			case "D#5": return 9;
			case "E5": 	return 10;
			case "F5": 	return 11;
			case "F#5": return 11;
			case "G5": 	return 12;
			case "G#5": return 12;
			case "A5": 	return 13;
			case "A#5": return 13;
			case "B5": 	return 14;
		}

		Debug.LogError("Error with name name conversion: " + note);
		return -1;
	}
}
