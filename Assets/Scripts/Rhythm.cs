using UnityEngine;

public class Rhythm : MonoBehaviour
{
    //The beats per minute the song has that we're trying to sync up to.
    public float SongBpm;

    //the number of seconds for each song beat
    public float SecPerBeat;

    //the current position of the song, measured in seconds.
    public float SongPosition;

    //the current position of the song, measured in beats. 
    public float SongPostiionInBeats;

    //how many seconds have passed since the song started.
    public float dspSongTime;

    //an AudioSource attached to this GameObject that will play the music. 
    public AudioSource musicSource;

    //keep all the position-in-beats of notes in the song
    float[] notes;

    //the index of the next note to be spawned
    int nextIndex = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Take the audiosource of the gameobject that this script is attached to.
        musicSource = GetComponent<AudioSource>();

        //calculate the number of seconds in each beat
        SecPerBeat = 60f/SongBpm;

        //record the time when the music starts
        dspSongTime = (float)AudioSettings.dspTime;
        Debug.Log(dspSongTime);

        //start the music
        musicSource.Play();


    }

    // Update is called once per frame
    void Update()
    {
        //determine  how many seconds since the song started
        SongPosition = (float)(AudioSettings.dspTime - dspSongTime);

        //determine how many beats since the song started
        SongPostiionInBeats = SongPosition/SecPerBeat;
    }
}
