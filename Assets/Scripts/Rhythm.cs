using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class Rhythm : MonoBehaviour
{
    [Header("Prefabs / References")]
    public GameObject MusicNotePrefab;
    public Transform[] Spawnpoints; // Assign all 4 spawnpoints in the Inspector
    public Transform[] Targets;     // Assign corresponding targets for each lane
    public AudioSource musicSource;

    [Header("Song Settings")]
    public float noteTravelTime = 2f;

    [Header("Calibration")]
    public float globalOffset = 0.15f;

    [Header("Debug")]
    public float SongPosition;

    private float[] notes;
    private int nextIndex = 0;

    void Start()
    {
        musicSource = GetComponent<AudioSource>();

        string path = Path.Combine(Application.dataPath, "Resources/GameJamFinal.osu");
        path = path.Replace("/", "\\");

        notes = LoadOsuNotes(path);

        Debug.Log("Notes Loaded: " + notes.Length);

        musicSource.Play();
    }

    void Update()
    {
        // Apply offset calibration
        SongPosition = musicSource.time - globalOffset;

        while (nextIndex < notes.Length &&
               SongPosition >= notes[nextIndex] - noteTravelTime)
        {
            SpawnNote(nextIndex);
            nextIndex++;
        }
    }

    void SpawnNote(int index)
    {
        int lane = Random.Range(0, Spawnpoints.Length);

        GameObject note = Instantiate(MusicNotePrefab, Spawnpoints[lane].position, Quaternion.identity);

        MusicNotes noteScript = note.GetComponent<MusicNotes>();
        noteScript.HitTime = notes[index];
        noteScript.target = Targets[lane];
        noteScript.noteTravelTime = noteTravelTime;
    }

    float[] LoadOsuNotes(string path)
    {
        List<float> noteTimes = new List<float>();
        string[] lines = File.ReadAllLines(path);

        bool inHitObjects = false;

        foreach (string line in lines)
        {
            if (line.StartsWith("[HitObjects]"))
            {
                inHitObjects = true;
                continue;
            }

            if (!inHitObjects) continue;
            if (string.IsNullOrWhiteSpace(line)) continue;

            string[] parts = line.Split(',');

            if (parts.Length < 3) continue;

            int timeMs = int.Parse(parts[2]);
            float timeSec = timeMs / 1000f;

            noteTimes.Add(timeSec);
        }

        return noteTimes.ToArray();
    }
}