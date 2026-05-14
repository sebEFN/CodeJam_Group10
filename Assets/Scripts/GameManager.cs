using JetBrains.Annotations;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;

    public TextMeshProUGUI scoreText; 

    public bool startPlaying;

    public BeatScroller theBS;

    public static GameManager instance;

    public int Score;

    public TextMeshProUGUI Hit;

    public TextMeshProUGUI Miss;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;

        Score = 0;

        SetScoreText();
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

    public void SetScoreText()
    {
        scoreText.text = "Score: " + Score.ToString();
    }

    public void NoteHit()
    {
        Score += 100;    

        Debug.Log("Hit On Time");
    }
     public void NoteMissed()
    {
        Debug.Log("Missed Note");
    }
}
