using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(AudioSource))]
public class KeyUI : MonoBehaviour, IPointerDownHandler
{
    AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        source.Play();
        Notes.Singleton.AddNote(source.clip.name);
    }
}
