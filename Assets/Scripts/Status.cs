using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Status : MonoBehaviour
{
	TMPro.TMP_Text text;
	[SerializeField] AudioClip winClip;
	[SerializeField] AudioClip loseClip;
	void OnEnable()
	{
		GetWinStatus();
	}
	void GetWinStatus()
	{
		for (int i = 0; i < Settings.maxNotes; i++)
		{
			var left = TrembleCleff.Singleton.notes[i].GetComponent<Note>();
			var right = SecretNotes.Singleton.secretNotes[i].GetComponent<Note>();
			if (left.clip == null || left.clip.name != right.clip.name)
			{

				text.text = "Not quite :(";
				return;
			}

		}
		text.text = "Pitch perfect :D";

	}
	void Awake()
	{
		text = GetComponent<TMPro.TMP_Text>();
	}
}
