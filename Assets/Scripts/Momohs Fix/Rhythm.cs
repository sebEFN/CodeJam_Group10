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
    public Transform[] laneSpawns;
    public Transform[] laneTargets;
    public KeyCode[] laneKeys;
    public List<MusicNotes>[] laneNotes;

    [Header("Song Settings")]
    public float noteTravelTime = 2f;

    [Header("Debug")]
    public float SongPosition;

    private List<NoteData> notes = new();
    private int nextIndex = 0;

    void Start()
    {
        musicSource = GetComponent<AudioSource>();

        string path = Path.Combine(Application.dataPath, "Resources/GameJamFinal.osu");
        path = path.Replace("/", "\\");

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
        NoteData data = notes[index];

        GameObject note = Instantiate(
            MusicNotePrefab,
            laneSpawns[data.lane].position,
            Quaternion.identity
        );

        MusicNotes noteScript = note.GetComponent<MusicNotes>();

        noteScript.HitTime = data.hitTime;
        noteScript.noteTravelTime = noteTravelTime;
        noteScript.target = laneTargets[data.lane];
        noteScript.lane = data.lane;
    }

    List<NoteData> LoadOsuNotes(string path)
    {
        List<NoteData> noteList = new();
        string[] lines = File.ReadAllLines(path);

        bool inHitObjects = false;

        foreach (string line in lines)
        {
            if (line.StartsWith("[HitObjects]"))
            {
                inHitObjects = true;
                continue;
            }

            if (!inHitObjects || string.IsNullOrWhiteSpace(line))
                continue;

            string[] parts = line.Split(',');

            int x = int.Parse(parts[0]);
            int timeMs = int.Parse(parts[2]);

            float timeSec = timeMs / 1000f;

            int lane = Mathf.Clamp(x / 128, 0, 3);

            noteList.Add(new NoteData(timeSec, lane));
        }

        return noteList;
    }


}