using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ButtonEffects : MonoBehaviour
{
	[SerializeField] AudioClip highlightedClip;
	[SerializeField] AudioClip pressedClip;

	AudioSource source;
	void Awake() => source = GetComponent<AudioSource>();
	public void PlayButtonHighlight()
	{
		source.PlayOneShot(highlightedClip);
	}
   	public void PlayPressedClip()
	{
		source.PlayOneShot(pressedClip);
	}

}
