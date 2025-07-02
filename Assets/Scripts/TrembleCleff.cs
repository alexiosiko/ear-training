using UnityEngine;
using UnityEngine.UI;
public class TrembleCleff : MonoBehaviour
{
	[SerializeField] GameObject noteObject;
	public RectTransform[] notes;
	int nextNoteIndex = 0;
	int hiddenNoteChildCount = 6;
	public void AddNote(AudioClip clip)
	{
		if (nextNoteIndex == Settings.maxNotes)
			return;


		RectTransform noteRect = notes[nextNoteIndex];
		Note note = noteRect.GetComponent<Note>();
		note.clip = clip;
		note.Reveal();

		int childIndex = Music.NoteNameToChildPosition(clip.name);
		Transform line = transform.GetChild(childIndex);
		noteRect.SetParent(line);

		noteRect.anchoredPosition = new(GetX(nextNoteIndex, GetComponent<RectTransform>()), 0);

		nextNoteIndex++;


	}
	public void RemoveLastNote()
	{
		if (nextNoteIndex == 0)
			return;

		nextNoteIndex--;

		RectTransform noteRect = notes[nextNoteIndex];
		noteRect.SetParent(transform.GetChild(hiddenNoteChildCount));
		Note note = noteRect.GetComponent<Note>();
		note.Hide();



		// int last = notes.Count - 1;               // correct index of last item
		// Destroy(notes[last].gameObject);          // destroy the UI note
		// notes.RemoveAt(last);                     // remove it from the list


	}
	void Awake()
	{
		


		Singleton = this;
	}
	void Start()
	{
		Invoke(nameof(LateStart), 0.1f);
	}
	void LateStart()
	{
		notes = new RectTransform[Settings.maxNotes];
		for (int i = 0; i < notes.Length; i++)
		{
			RectTransform h = Instantiate(noteObject).GetComponent<RectTransform>();
			h.SetParent(transform.GetChild(hiddenNoteChildCount), false	);
			notes[i] = h;
			h.GetComponent<Note>().Hide();

		}
		for (int i = 0; i < notes.Length; i++)
		{
			RectTransform h = notes[i];
			h.anchoredPosition = new Vector2(GetX(i, GetComponent<RectTransform>()), 0);
		}

	}

	public static float GetX(int noteNumber, RectTransform trembleRectTransform)
	{
		print(trembleRectTransform.rect.width);
		float padding = 400f;
		float leftPadding = 40f;
		float width = trembleRectTransform.rect.width - padding;
		float gap = width / (Settings.maxNotes - 1);
		float x = -width / 2f + gap * noteNumber + leftPadding;
		return x;
	}

	public void ResetNotes()
	{
		for (int i = 0; i < notes.Length; i++)
			RemoveLastNote();
	}
	
	public void Play()
	{
		TrembleCleffSound.Singleton.Play(notes, notes);
	}

	public static TrembleCleff Singleton;

}


