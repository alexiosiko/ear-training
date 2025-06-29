using System;
using System.Collections.Generic;

public static class Music
{
	public enum Scale { minor, major }
	public enum Key { C, D, E, F, G, A, B }  // Removed H for music standard

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

	public static string[] GetNotesInScale()
	{

		// Find root index of key, first occurrence in octave 4
		string rootNote = Settings.key.ToString() + "4";
		int rootIndex = System.Array.IndexOf(notes, rootNote);
		if (rootIndex == -1) return new string[0];

		int[] intervals = scales[Settings.scale];
		List<string> scaleNotes = new List<string>();

		foreach (int interval in intervals)
		{
			int noteIndex = rootIndex + interval;

			// If index goes beyond notes array, wrap into next octave (handle only 2 octaves here)
			if (noteIndex >= notes.Length)
				noteIndex -= 12; // one octave down, or customize as needed

			scaleNotes.Add(notes[noteIndex]);
		}
		return scaleNotes.ToArray();
	}
	private static Random rng = new Random();

    public static string[] PickRandomNotes(string[] notesInScale, int count)
    {
        if (count >= notesInScale.Length)
            return notesInScale; // return all if count >= available notes

        // Copy array to list for shuffling
        List<string> notesList = new List<string>(notesInScale);

        // Fisher-Yates shuffle
        int n = notesList.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            string temp = notesList[k];
            notesList[k] = notesList[n];
            notesList[n] = temp;
        }

        // Take first 'count' notes after shuffle
        return notesList.GetRange(0, count).ToArray();
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
