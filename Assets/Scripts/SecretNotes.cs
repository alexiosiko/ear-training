using System.Collections.Generic;
using UnityEngine;

public class SecretNotes : MonoBehaviour
{
	public RectTransform[] secretNotes;
	[SerializeField] GameObject noteObject;
	[SerializeField] Transform secretTrembleCleffTransform;
	public void AddSecretNote(AudioClip clip)
	{


		int childCount = Music.NoteNameToChildPosition(clip.name);

		// Instantiate note
		GameObject newNoteObj = Instantiate(noteObject, secretTrembleCleffTransform);

		// Store name in note
		newNoteObj.GetComponent<Note>().clip = clip;
		newNoteObj.GetComponent<Note>().Reveal();

		RectTransform newNoteRect = newNoteObj.GetComponent<RectTransform>();

		// Parent to correct line
		Transform line = secretTrembleCleffTransform.GetChild(childCount);
		newNoteRect.SetParent(line);



	}

	[SerializeField] AudioClip[] clipsInScale;

	public void Shuffle()
	{
		AudioClip[] audioClips = Music.PickRandomClips(clipsInScale, Settings.maxNotes);
		for (int i = 0; i < secretNotes.Length; i++)
		{
			RectTransform t = secretNotes[i];
			Note note = t.GetComponent<Note>();
			note.clip = audioClips[i];
			note.Reveal();

			// Parent to correct line
			int childCount = Music.NoteNameToChildPosition(audioClips[i].name);
			Transform line = secretTrembleCleffTransform.GetChild(childCount);
			t.SetParent(line);

			t.anchoredPosition = new(TrembleCleff.GetX(i, secretTrembleCleffTransform.GetComponent<RectTransform>()), 0);
		}
	}
	void Start()
	{
		clipsInScale = Music.GetClipsInScale();
		secretNotes = new RectTransform[Settings.maxNotes];
		for (int i = 0; i < secretNotes.Length; i++)
			secretNotes[i] = Instantiate(noteObject).GetComponent<RectTransform>();

		Shuffle();
		Singleton = this;
	}
	public void Play()
	{
		TrembleCleffSound.Singleton.Play(secretNotes, secretNotes);
	}
	public static SecretNotes Singleton;
	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.S))
			Shuffle();
	}
}
