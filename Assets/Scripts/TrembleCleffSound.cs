using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class TrembleCleffSound : MonoBehaviour
{
	public void Play(ref List<RectTransform> notes)
	{
		StopAllCoroutines();
		StartCoroutine(IPlay(notes));
	}
	IEnumerator IPlay(List<RectTransform> notes)
	{
		foreach (var r in notes)
		{
			yield return new WaitForSeconds(0.5f);
		}
	}
	void Awake()
	{
		Singleton = this;
	}
	public static TrembleCleffSound Singleton;
}
