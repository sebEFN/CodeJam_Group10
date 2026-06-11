using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class Rhythm : MonoBehaviour
{
    [Header("Prefabs / References")]
    public GameObject MusicNotePrefab;
    public Transform Spawnpoint;
    public Transform targetTransform;
    public AudioSource musicSource;

    [Header("Song Settings")]
    public float noteTravelTime = 2f;

    [Header("Debug")]
    public float SongPosition;

    private float[] notes;
    private int nextIndex = 0;

    void Start()
    {
        musicSource = GetComponent<AudioSource>();

        string path = Path.Combine(Application.dataPath, "Resources\\GameJamFinal.osu");
        

        notes = LoadOsuNotes(path);

        Debug.Log("Notes Loaded: " + notes.Length);

        // IMPORTANT: normal play (no DSP scheduling)
        musicSource.Play();
    }

    void Update()
    {
        // ✅ FIX: use actual audio playback time (prevents drift)
        SongPosition = musicSource.time;

        while (nextIndex < notes.Length &&
               SongPosition >= notes[nextIndex] - noteTravelTime)
        {
            SpawnNote(nextIndex);
            nextIndex++;
        }
    }

    void SpawnNote(int index)
    {
<<<<<<< Updated upstream
        GameObject note = Instantiate(MusicNotePrefab, Spawnpoint.position, Quaternion.identity);
=======
        NoteData noteData = notes[index];

        int lane = noteData.lane;

    

        GameObject note = Instantiate(
            MusicNotePrefab,
            laneSpawnPoints[lane].position,
            Quaternion.identity
        );
>>>>>>> Stashed changes

        MusicNotes noteScript = note.GetComponent<MusicNotes>();
        noteScript.HitTime = notes[index];
        noteScript.target = targetTransform;
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