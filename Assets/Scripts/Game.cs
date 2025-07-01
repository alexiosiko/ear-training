using UnityEngine;

public class Game : MonoBehaviour
{
	public AudioClip[] allClips; // All C4–B5 clips
	public void Reset()
	{
		FindFirstObjectByType<TrembleCleff>().ResetNotes();

		FindFirstObjectByType<SecretNotes>().Shuffle();

		FindFirstObjectByType<Reveal>().Close();

	}
	void Awake()
	{
		Singleton = this;
	}
	public static Game Singleton;

}
