using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(BoxCollider2D))]
public class Key : MonoBehaviour
{
	void OnMouseDown()
	{
		source.Play();	
		Notes.inge
	}
	AudioSource source;
	void Awake()
	{
		source = GetComponent<AudioSource>();
	}
}
