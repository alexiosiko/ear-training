using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(BoxCollider2D))]
public class Key : MonoBehaviour
{
	void OnMouseDown()
	{
		source.Play();	
		Notes.Singleton.AddNote(source.c)
	}
	AudioSource source;
	void Awake()
	{
		source = GetComponent<AudioSource>();
	}
}
