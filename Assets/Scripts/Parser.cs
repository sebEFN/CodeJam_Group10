using System.Collections.Generic;
using UnityEngine;

public class OsuManiaParser : MonoBehaviour
{
    public TextAsset osuFile;
    public int keyCount = 4; // set this to your map (4K, 5K, 7K, etc.)

    public List<ManiaNote> notes = new List<ManiaNote>();

    void Start()
    {
        Parse();
    }

    void Parse()
    {
        string[] lines = osuFile.text.Split('\n');

        bool inHitObjects = false;

        foreach (string rawLine in lines)
        {
            string line = rawLine.Trim();

            if (line.StartsWith("[HitObjects]"))
            {
                inHitObjects = true;
                continue;
            }

            if (!inHitObjects || string.IsNullOrEmpty(line))
                continue;

            string[] parts = line.Split(',');

            if (parts.Length < 5)
                continue;

            float x = float.Parse(parts[0]);
            float time = float.Parse(parts[2]) / 1000f;
            int type = int.Parse(parts[3]);

            // Convert X position → lane
            int lane = Mathf.FloorToInt((x / 512f) * keyCount);
            lane = Mathf.Clamp(lane, 0, keyCount - 1);

            ManiaNote note = new ManiaNote();
            note.lane = lane;
            note.time = time;

         

            notes.Add(note);
        }

        Debug.Log("Parsed notes: " + notes.Count);
    }
}