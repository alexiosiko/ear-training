using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(BoxCollider2D))]
public class Key : MonoBehaviour
{
	[SerializeField] AudioClip note;
	AudioSource source;
	void Awake()
	{
		source = GetComponent<AudioSource>();
	}
	void OnMouseDown()
	{
		source.Play();	
	}

}
