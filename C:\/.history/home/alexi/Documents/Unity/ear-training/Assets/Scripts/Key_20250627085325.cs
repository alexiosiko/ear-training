using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(BoxCollider2D))]
public class Key : MonoBehaviour
{
	[SerializeField] AudioClip note;
	
	void OnMouseDown()
	{
		source.Play();	
	}
	AudioSource source;
	void Awake()
	{
		source = GetComponent<AudioSource>();
	}
}
