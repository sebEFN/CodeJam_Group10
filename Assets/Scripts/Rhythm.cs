using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class Rhythm : MonoBehaviour
{
    public GameObject MusicNotePrefab;
    
    //The beats per minute the song has that we're trying to sync up to.
    public float SongBpm;

    public float noteTravelTime = 2f;

    //the number of seconds for each song beat
    public float SecPerBeat;

    //the current position of the song, measured in seconds.
    public float SongPosition;

    //the current position of the song, measured in beats. 
    public float SongPositionInBeats;

    //how many seconds have passed since the song started.
    public float dspSongTime;

    public float beatsShownInAdvance = 3f;

    //an AudioSource attached to this GameObject that will play the music. 
    public AudioSource musicSource;

    public Transform Spawnpoint; 

<<<<<<< Updated upstream
    public Transform targetTransform;

    //keep all the position-in-beats of notes in the song
    float[] notes;
=======
       
        musicSource.Play();
    }

    void Update()
    {
       
        SongPosition = musicSource.time;
>>>>>>> Stashed changes

    //the index of the next note to be spawned
    int nextIndex = 0;

    float offset = 0.05f;

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

            if (inHitObjects)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                string[] parts = line.Split(',');

                int timeMs = int.Parse(parts[2]);

                float timeSec = timeMs / 1000f - offset;

                noteTimes.Add(timeSec);
            }
        }

        return noteTimes.ToArray();
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Take the audiosource of the gameobject that this script is attached to.
        musicSource = GetComponent<AudioSource>();

        //calculate the number of seconds in each beat
        SecPerBeat = 60f/SongBpm;

        //Load Osu! beatmap into the notes array in seconds
        string path = Path.Combine(Application.dataPath, "Resources/GameJamFinal.osu");
        path = path.Replace("/","\\" );
        Debug.Log(path);
        notes = LoadOsuNotes(path);
        Debug.Log("Notes Loaded: " + notes.Length);
        
        //schedule the music and align song timing to the actual start time
        double startTime = AudioSettings.dspTime + 0.1;
        dspSongTime = (float)startTime;
        musicSource.PlayScheduled(startTime);


    }

    // Update is called once per frame
    void Update()
    {
        //determine  how many seconds since the song started
        SongPosition = (float)(AudioSettings.dspTime - dspSongTime);

        //determine how many beats since the song started
        SongPositionInBeats = SongPosition/SecPerBeat;

        if (nextIndex < notes.Length && SongPosition >= notes[nextIndex] - noteTravelTime)
            {
                GameObject note = Instantiate(MusicNotePrefab, Spawnpoint.position, Quaternion.identity);

                MusicNotes noteScript = note.GetComponent<MusicNotes>();
                noteScript.HitTime = notes[nextIndex];
                noteScript.target = targetTransform;
                noteScript.noteTravelTime = noteTravelTime;

                //initialize the fields of the music note
                nextIndex++;
            }
    }
}
