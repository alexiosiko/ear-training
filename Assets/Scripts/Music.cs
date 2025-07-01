using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

public static class Music
{
	public enum Scale { minor, major }
	public enum Key { C, Cs,  D, Ds, E, F, Fs,  G, Gs, A, As, B }  // Removed H for music standard

	public static readonly string[] notes = {
		"C4", "C#4", "D4", "D#4", "E4", "F4",
		"F#4", "G4", "G#4", "A4", "A#4", "B4",
		"C5", "C#5", "D5", "D#5", "E5", "F5",
		"F#5", "G5", "G#5", "A5", "A#5", "B5"
	};

	static readonly Dictionary<Scale, int[]> scales = new Dictionary<Scale, int[]>
	{
		{ Scale.minor, new int[] { 0, 2, 3, 5, 7, 8, 10 } },
		{ Scale.major, new int[] { 0, 2, 4, 5, 7, 9, 11 } },
	};

	public static AudioClip[] GetClipsInScale()
	{
		string[] noteNames = GetNotesInScale();
		Debug.Log(noteNames.ToCommaSeparatedString());
		List<AudioClip> filtered = new();

		foreach (string name in noteNames)
		{
			foreach (AudioClip clip in Game.Singleton.allClips)
			{
				if (clip.name == name)
				{
					filtered.Add(clip);
					break;
				}
			}
		}

		return filtered.ToArray();
	}

	public static string[] GetNotesInScale()
{
	// Get saved values from PlayerPrefs
	string keyStr = PlayerPrefs.GetString("Key", "C");
	keyStr = keyStr.Replace('#', 's');
	string scaleStr = PlayerPrefs.GetString("Scale", "minor").ToLower();

		Debug.Log(keyStr);


	// Parse enums
		if (!Enum.TryParse<Key>(keyStr, out Key key)) return new string[0];
	if (!Enum.TryParse<Scale>(scaleStr, out Scale scale)) return new string[0];
	


	// Find root note
	string rootNote = key.ToString() + "4";
	rootNote = rootNote.Replace('s', '#');
	int rootIndex = Array.IndexOf(notes, rootNote);
	if (rootIndex == -1) return new string[0];

	// Build scale
	int[] intervals = scales[scale];
	List<string> scaleNotes = new();

	foreach (int interval in intervals)
	{
		int noteIndex = rootIndex + interval;
		if (noteIndex >= notes.Length) noteIndex -= 12;
		scaleNotes.Add(notes[noteIndex]);
	}

	
	return scaleNotes.ToArray();
}

	private static System.Random rng = new System.Random();

    public static AudioClip[] PickRandomClips(AudioClip[] clipsInScale, int count)
	{
		if (count >= clipsInScale.Length)
			return clipsInScale;

		List<AudioClip> list = new(clipsInScale);

		// Fisher-Yates shuffle
		int n = list.Count;
		while (n > 1)
		{
			n--;
			int k = rng.Next(n + 1);
			(list[k], list[n]) = (list[n], list[k]);
		}

		return list.GetRange(0, count).ToArray();
	}

	public static int NoteNameToChildPosition(string note)
	{
		switch (note)
		{
			case "C4": return 1;
			case "C#4": return 1;
			case "D4": return 2;
			case "D#4": return 2;
			case "E4": return 3;
			case "F4": return 4;
			case "F#4": return 4;
			case "G4": return 5;
			case "G#4": return 5;
			case "A4": return 6;
			case "A#4": return 6;
			case "B4": return 7;
			case "C5": return 8;
			case "C#5": return 8;
			case "D5": return 9;
			case "D#5": return 9;
			case "E5": return 10;
			case "F5": return 11;
			case "F#5": return 11;
			case "G5": return 12;
			case "G#5": return 12;
			case "A5": return 13;
			case "A#5": return 13;
			case "B5": return 14;
		}

		return -1;
	}
}
