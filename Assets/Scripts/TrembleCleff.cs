using UnityEngine;
using System.Collections.Generic;


public class TrembleCleff : MonoBehaviour
{
	[SerializeField] Music.Scale scale = Music.Scale.minor;
	[SerializeField] Music.Key key = Music.Key.E;
	[SerializeField] string[] notesInScale;
	[SerializeField] GameObject noteObject;
	List<RectTransform> notes;
	List<RectTransform> secretNotes;
	int maxNotes = 5;
	public void AddNote(string noteName)
	{
		int childCount = Music.NoteNameToChildPosition(noteName);
		if (notes.Count == maxNotes)
			return;

		// Instantiate under the UI parent (do not set position/rotation)
		GameObject newNoteObj = Instantiate(noteObject, transform);
		RectTransform newNoteRect = newNoteObj.GetComponent<RectTransform>();

		Transform line = transform.GetChild(childCount);
		newNoteRect.SetParent(line);


		float padding = 200f;

		// Get x pos
		float totalWidth = transform.GetComponent<RectTransform>().rect.width - padding;
		float gap = totalWidth / maxNotes;
		float x = gap * notes.Count - totalWidth / 2f + padding / 2f;

		// Set x pos
		newNoteRect.anchoredPosition = new(x, 0);

		// Store
		notes.Add(newNoteRect);
	}
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

		if (secretNotes.Count == maxNotes)
			return;

		int childCount = Music.NoteNameToChildPosition(noteName);

		// Instantiate note
		GameObject newNoteObj = Instantiate(noteObject, transform);
		RectTransform newNoteRect = newNoteObj.GetComponent<RectTransform>();

		// Parent to correct line
		Transform line = transform.GetChild(childCount);
		newNoteRect.SetParent(line);

		// Positioning
		float padding = 200f;
		float totalWidth = transform.GetComponent<RectTransform>().rect.width - padding;
		float gap = totalWidth / maxNotes;
		float x = gap * secretNotes.Count - totalWidth / 2f + padding / 2f;

		newNoteRect.anchoredPosition = new(x, 0);

		// Store
		secretNotes.Add(newNoteRect);
	}


	public void RemoveLastNote()
	{
		if (notes.Count == 0)
			return;

		int last = notes.Count - 1;               // correct index of last item
		Destroy(notes[last].gameObject);          // destroy the UI note
		notes.RemoveAt(last);                     // remove it from the list

	}
	public static TrembleCleff Singleton;
	void Awake()
	{
		Singleton = this;
		ResetNotes();

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
	public void Shuffle()
	{
		DeleteSecretNotes();

		string[] notes = Music.PickRandomNotes(notesInScale, maxNotes);
		foreach (string note in notes)
			AddSecretNote(note);
	}

	public void GetNotesInScale()
	{
		notesInScale = Music.GetNotesInScale(key, scale);
	}
	Dictionary<string, int[]> scales = new Dictionary<string, int[]>
	{
		{ "minor", new int[] { 0, 2, 3, 5, 7, 8, 10, 12 }},
		{ "major", new int[] { 0, 2, 4, 5, 7, 9, 11, 12 }},
	};
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.G))
			GetNotesInScale();
		if (Input.GetKeyDown(KeyCode.S))
			Shuffle();
	}

}


