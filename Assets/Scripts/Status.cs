using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Status : MonoBehaviour
{
	TMPro.TMP_Text text;
	[SerializeField] AudioClip winClip;
	[SerializeField] AudioClip loseClip;
	AudioSource source;

	public void GetWinStatus()
	{
		if (SecretNotes.Singleton?.secretNotes == null) return;

		for (int i = 0; i < Settings.maxNotes; i++)
		{
			var left = TrembleCleff.Singleton.notes[i]?.GetComponent<Note>();
			var rightRect = SecretNotes.Singleton.secretNotes[i];
			if (rightRect == null) return;

			var right = rightRect.GetComponent<Note>();

			if (left?.clip == null || right?.clip == null || left.clip.name != right.clip.name)
			{
				source.PlayOneShot(loseClip);
				text.text = "Not quite :(";
				return;
			}
		}
		source.PlayOneShot(winClip);
		text.text = "Pitch perfect :D";
	}

	void Awake()
	{
		text = GetComponent<TMPro.TMP_Text>();
		source = GetComponent<AudioSource>();
	}
}
