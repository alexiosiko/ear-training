using UnityEngine;
public class Note : MonoBehaviour
{
	public string note;
	void Start()
	{
		if (note.Contains('#'))
			transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().enabled = true;

	}
}
