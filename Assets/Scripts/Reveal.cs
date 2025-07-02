using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class Reveal : MonoBehaviour
{
	bool open = false;
	Vector3 closedPosition = new(0, -1000);
	RectTransform rect;
	public void Toggle()
	{
		if (open)
			Close();
		else
		{
			StopAllCoroutines();
			open = true;
			transform.GetChild(0).gameObject.SetActive(true);
			rect.DOKill();
			rect.DOAnchorPos(new(0, 0), 0.5f);
		}
	}
	void Awake()
	{
		rect = transform.GetChild(0).GetComponent<RectTransform>();
		rect.anchoredPosition = new(0, -1000);
		Singleton = this;
	}
	IEnumerator DelayDisable()
	{
		yield return new WaitForSeconds(0.5f);
		transform.GetChild(0).gameObject.SetActive(false);

	}
	public void Close()
	{

		open = false;
		rect.DOKill();
		rect.DOAnchorPos(closedPosition, 0.5f);
		StopAllCoroutines();
		StartCoroutine(DelayDisable());
	}

	public static Reveal Singleton;
}
