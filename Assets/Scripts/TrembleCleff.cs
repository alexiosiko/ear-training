using UnityEngine;
using System.Collections.Generic;


public class TrembleCleff : MonoBehaviour
{

	[SerializeField] GameObject noteObject;
	List<RectTransform> notes;

	public void AddNote(string noteName)
	{
		int childCount = Music.NoteNameToChildPosition(noteName);
		if (notes.Count == Settings.maxNotes)
			return;

		// Instantiate under the UI parent (do not set position/rotation)
		GameObject newNoteObj = Instantiate(noteObject, transform);

		// Store name in note
		print(noteName);
		newNoteObj.GetComponent<Note>().note = noteName;

		RectTransform newNoteRect = newNoteObj.GetComponent<RectTransform>();

		Transform line = transform.GetChild(childCount);
		newNoteRect.SetParent(line);


		float padding = 200f;

		// Get x pos
		float totalWidth = transform.GetComponent<RectTransform>().rect.width - padding;
		float gap = totalWidth / Settings.maxNotes;
		float x = gap * notes.Count - totalWidth / 2f + padding / 2f;

		// Set x pos
		newNoteRect.anchoredPosition = new(x, 0);

		// Store
		notes.Add(newNoteRect);
	}
	public void RemoveLastNote()
	{
		if (notes.Count == 0)
			return;

		int last = notes.Count - 1;               // correct index of last item
		Destroy(notes[last].gameObject);          // destroy the UI note
		notes.RemoveAt(last);                     // remove it from the list

	}

	void ResetNotes()
	{
		if (notes != null)
			foreach (RectTransform note in notes)
				Destroy(note.gameObject);
		else
			notes = new List<RectTransform>();

		notes.Clear();
	}
	




	public static TrembleCleff Singleton;
	void Awake()
	{
		Singleton = this;
		ResetNotes();

	}

}


