using UnityEngine;

public class Notes : MonoBehaviour
{
	[SerializeField] Transform noteTransform;
	public void AddNote(string note)
	{
		Instantiate(noteTransform, Vector3.zero, Quaternion.identity, transform);
	}
	public void RemoveLastNote()
	{
		if (transform.childCount == 0)
			return;
		Transform note = transform.GetChild(transform.childCount - 1);
		Destroy(note);
	}
	void FormatNotes()
	{

	}
	public static Notes Singleton;
	void Awake()
	{
		Singleton = this;
	}
}
