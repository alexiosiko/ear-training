using System.Collections.Generic;
using UnityEngine;

public class SecretNotes : MonoBehaviour
{
	[SerializeField] string[] notesInScale;
	List<RectTransform> secretNotes;
	[SerializeField] GameObject noteObject;
	public void DeleteSecretNotes()
	{
		if (secretNotes != null)
			foreach (RectTransform note in secretNotes)
				Destroy(note.gameObject);
		else
			secretNotes = new List<RectTransform>();


		secretNotes.Clear(); // Clear after loop
	}

	public void AddSecretNote(string noteName)
	{

		if (secretNotes == null)
			secretNotes = new List<RectTransform>();

		if (secretNotes.Count == Settings.maxNotes)
			return;

		int childCount = Music.NoteNameToChildPosition(noteName);

		// Instantiate note
		GameObject newNoteObj = Instantiate(noteObject, transform);

		// Store name in note
		newNoteObj.GetComponent<Note>().note = noteName;

		RectTransform newNoteRect = newNoteObj.GetComponent<RectTransform>();

		// Parent to correct line
		Transform line = transform.GetChild(childCount);
		newNoteRect.SetParent(line);

		// Positioning
		float padding = 200f;
		float totalWidth = transform.GetComponent<RectTransform>().rect.width - padding;
		float gap = totalWidth / Settings.maxNotes;
		float x = gap * secretNotes.Count - totalWidth / 2f + padding / 2f;

		newNoteRect.anchoredPosition = new(x, 0);

		// Store
		secretNotes.Add(newNoteRect);
	}

	public void Shuffle()
	{
		DeleteSecretNotes();

		string[] notes = Music.PickRandomNotes(notesInScale, Settings.maxNotes);
		foreach (string note in notes)
			AddSecretNote(note);
	}
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.G))
			GetNotesInScale();
		if (Input.GetKeyDown(KeyCode.S))
			Shuffle();
	}
	
	public void GetNotesInScale()
	{
		notesInScale = Music.GetNotesInScale();
	}
}
