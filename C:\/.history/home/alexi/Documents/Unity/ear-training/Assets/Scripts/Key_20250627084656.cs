using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(BoxCollider))]
public class Key : MonoBehaviour
{
	[SerializeField] AudioClip note;
	[SerializeField] AudioSource source;
	void Awake()
	{
		source = GetComponent<AudioSource>();
	}
	
}
