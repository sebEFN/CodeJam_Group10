using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class Rhythm : MonoBehaviour
{
    [System.Serializable]
    public class NoteData
    {
        public float time;
        public int lane;
    }

    [Header("Prefabs / References")]
    public GameObject MusicNotePrefab;

    [Header("Lane Spawn Points")]
    public Transform[] laneSpawnPoints;

    [Header("Lane Targets")]
    public Transform[] laneTargets;

    public AudioSource musicSource;

    [Header("Song Settings")]
    public float noteTravelTime = 2f;

    [Header("Debug")]
    public float SongPosition;

    private NoteData[] notes;
    private int nextIndex = 0;

    public static Rhythm instance;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        musicSource = GetComponent<AudioSource>();

        string path = Path.Combine(Application.dataPath, "Resources/GameJamFinal.osu");
        path = path.Replace("/", "\\");

        notes = LoadOsuNotes(path);

        Debug.Log("Notes Loaded: " + notes.Length);

        // Start music
        musicSource.Play();
    }

    void Update()
    {
        // Current song time
        SongPosition = musicSource.time;

        // Spawn notes early enough to reach target on beat
        while (
            nextIndex < notes.Length &&
            SongPosition >= notes[nextIndex].time - noteTravelTime
        )
        {
            SpawnNote(nextIndex);
            nextIndex++;
        }
    }

    void SpawnNote(int index)
    {
        NoteData noteData = notes[index];

        int lane = noteData.lane;

        // Safety check
        if (lane < 0 || lane >= laneSpawnPoints.Length)
        {
            Debug.LogWarning("Invalid lane: " + lane);
            return;
        }

        GameObject note = Instantiate(
            MusicNotePrefab,
            laneSpawnPoints[lane].position,
            Quaternion.identity
        );

        MusicNotes noteScript = note.GetComponent<MusicNotes>();

        noteScript.HitTime = noteData.time;
        noteScript.target = laneTargets[lane];
        noteScript.noteTravelTime = noteTravelTime;
    }

    NoteData[] LoadOsuNotes(string path)
    {
        List<NoteData> noteList = new List<NoteData>();

        string[] lines = File.ReadAllLines(path);

        bool inHitObjects = false;

        foreach (string line in lines)
        {
            if (line.StartsWith("[HitObjects]"))
            {
                inHitObjects = true;
                continue;
            }

            if (!inHitObjects)
                continue;

            if (string.IsNullOrWhiteSpace(line))
                continue;

            string[] parts = line.Split(',');

            if (parts.Length < 3)
                continue;

            // osu format:
            // x,y,time,type,hitSound,...

            int xPos = int.Parse(parts[0]);
            int timeMs = int.Parse(parts[2]);

            float timeSec = timeMs / 1000f;

            int lane = GetLaneFromX(xPos);

            NoteData note = new NoteData
            {
                time = timeSec,
                lane = lane
            };
            Debug.Log("xPos: " + xPos + " -> Lane: " + lane);
            noteList.Add(note);
        }

        return noteList.ToArray();
    }

    int GetLaneFromX(int x)
    {
        // osu playfield width = 512
        // 4 lane conversion

        if (x <= 154)
            return 0;

        if (x <= 256)
            return 1;

        if (x <= 384)
            return 2;

        return 3;
    }
}
