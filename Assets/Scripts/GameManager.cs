using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioSource theMusic; 

    public bool startPlaying;

    public BeatScroller theBS;

    public static GameManager instance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown || Input.touchCount > 0)
            {
                startPlaying = true;
                theBS.hasStarted = true;
                theMusic.Play();
            }
        }
    }

    public void NoteHit()
        {
        Debug.Log("Hit On Time");
    }
     public void NoteMissed()
        {
        Debug.Log("Missed Note");
    }
}
