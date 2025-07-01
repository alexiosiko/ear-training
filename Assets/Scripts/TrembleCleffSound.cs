using System.Collections;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(AudioSource))]
public class TrembleCleffSound : MonoBehaviour
{
	[SerializeField] AudioClip emptyNoteClip;
	public void Play(RectTransform[] notes, RectTransform[] noteSounds)
	{
		if (iPlay == null)
			iPlay = StartCoroutine(IPlay(notes, noteSounds));
	}

	Coroutine iPlay;
	IEnumerator IPlay(RectTransform[] notes, RectTransform[] noteSounds)
	{
		for (int i = 0; i < notes.Length; i++)
		{
			var note = notes[i];

			note.DOShakeAnchorPos(0.5f, 10);
			note.DOShakeRotation(0.5f, 25);



			source.clip = noteSounds[i].GetComponent<Note>().clip;
			if (source.clip)
				source.Play();
			else
				source.PlayOneShot(emptyNoteClip);

			yield return new WaitForSeconds(0.5f);


		}
		iPlay = null;
	}


	void Awake()
	{
		Singleton = this;
		source = GetComponent<AudioSource>();
	}
	public static TrembleCleffSound Singleton;
	AudioSource source;
}
