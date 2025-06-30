using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(AudioSource))]
public class Key : MonoBehaviour, IPointerDownHandler
{
    AudioSource source;
	[SerializeField] TrembleCleff[] trembleCleffs;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        source.Play();

		foreach (var t in trembleCleffs)
			t.AddNote(source.clip);	
    }
}
