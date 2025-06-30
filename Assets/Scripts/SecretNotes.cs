using System.Collections.Generic;
using UnityEngine;

public class SecretNotes : MonoBehaviour
{
	List<RectTransform> secretNotes;
	[SerializeField] GameObject noteObject;
	[SerializeField] Transform secretTrembleCleffTransform;
	public void ResetNotes()
	{
		if (secretNotes != null)
			foreach (RectTransform note in secretNotes)
				Destroy(note.gameObject);
		else
			secretNotes = new List<RectTransform>();


		secretNotes.Clear(); // Clear after loop
	}

	public void AddSecretNote(AudioClip clip)
	{

		if (secretNotes == null)
			secretNotes = new List<RectTransform>();

		if (secretNotes.Count == Settings.maxNotes)
			return;

		int childCount = Music.NoteNameToChildPosition(clip.name);

		// Instantiate note
		GameObject newNoteObj = Instantiate(noteObject, secretTrembleCleffTransform);

		// Store name in note
		newNoteObj.GetComponent<Note>().clip = clip;

		RectTransform newNoteRect = newNoteObj.GetComponent<RectTransform>();

		// Parent to correct line
		Transform line = secretTrembleCleffTransform.GetChild(childCount);
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

	[SerializeField] AudioClip[] clipsInScale;

	public void Shuffle()
	{
		ResetNotes();
		var chosen = Music.PickRandomClips(clipsInScale, Settings.maxNotes);
		foreach (var clip in chosen)
			AddSecretNote(clip);
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.G))
			GetNotesInScale();
		if (Input.GetKeyDown(KeyCode.S))
			Shuffle();
	}
	void Awake()
	{
		GetNotesInScale();
		Shuffle();
	}

	public void GetNotesInScale()
	{
		clipsInScale = Music.GetClipsInScale();
	}
}
