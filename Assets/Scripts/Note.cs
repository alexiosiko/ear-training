using UnityEngine;
using UnityEngine.UI;
public class Note : MonoBehaviour
{
	[SerializeField] Sprite noteSprite;
	[SerializeField] Sprite eyeSprite;
	public AudioClip clip;
	public void Hide()
	{
		image.sprite = eyeSprite;
		transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().enabled = false;
	}
	public void Reveal()
	{
		image.sprite = noteSprite;
		if (clip == null)
			Debug.LogError("Note clip is empty.", this);
		if (clip.name.Contains('#'))
				transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().enabled = true;
			else
				transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().enabled = false;
			
	}
	Image image;

	void Awake()
	{
		image = GetComponent<Image>();
	}
}
