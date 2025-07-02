using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
	[SerializeField] AudioSource removeNoteSource;
	[SerializeField] AudioSource shuffleSource;
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Backspace))
		{
			removeNoteSource.Play();
			TrembleCleff.Singleton.RemoveLastNote();
		}

		if (Input.GetKeyDown(KeyCode.Return))
		{
			TrembleCleff.Singleton.Play();
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			SecretNotes.Singleton.Play();
		}

		if (Input.GetKeyDown(KeyCode.S))
		{
			shuffleSource.Play();
			Game.Singleton.Reset();
		}

		if (Input.GetKeyDown(KeyCode.R))
		{
			Reveal.Singleton.Toggle();
		}
	}

}
