using UnityEngine;
public class Note : MonoBehaviour
{
	public AudioClip clip;
	void Start()
	{
		if (clip.name.Contains('#'))
			transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().enabled = true;

	}
}
