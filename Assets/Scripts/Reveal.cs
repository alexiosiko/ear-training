using UnityEngine;

public class Reveal : MonoBehaviour
{
	bool open = false;
	public void Toggle()
	{
		if (open)
		{
			open = false;
			transform.GetChild(0).gameObject.SetActive(false);
		}
		else
		{
			open = true;
			transform.GetChild(0).gameObject.SetActive(true);
		}
	}
	public void Close()
	{
		open = false;
		transform.GetChild(0).gameObject.SetActive(false);
	}
}
