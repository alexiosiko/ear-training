using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(AudioSource))]
public class Key : MonoBehaviour, IPointerDownHandler
{
    AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        source.Play();
        Notes.Singleton.AddNote(Notes.source.clip.name);
    }
}
