using UnityEngine;
using UnityEngine.EventSystems
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(BoxCollider2D))]
public class Key : MonoBehaviour, IPointerDownHandler
{
	void OnMouseDown()
	{
		source.Play();
		Notes.Singleton.AddNote(source.clip.name);
	}
	AudioSource source;
	void Awake()
	{
		source = GetComponent<AudioSource>();
	}
}
