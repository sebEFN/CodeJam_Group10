using JetBrains.Annotations;
using UnityEngine;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;

    public TextMeshProUGUI scoreText; 

    public bool startPlaying;

    public BeatScroller theBS;

    public static GameManager instance;

    public Transform HitSpawn;
    public Transform MissSpawn;

    public int Score;

    public GameObject Hitprefab;
    public GameObject Missprefab;
    public TMP_FontAsset TextFont;

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
        StartCoroutine("SpawnHit");   

        Debug.Log("Hit On Time");
    }
     public void NoteMissed()
    {
        Debug.Log("Missed Note");

        StartCoroutine("SpawnMiss");
    }

    public IEnumerator SpawnHit()
    {
        Score += 100;
        SetScoreText();

        GameObject hitText = new GameObject("HitText");
        hitText.transform.position = HitSpawn.position;

        TextMeshPro tmp = hitText.AddComponent<TextMeshPro>();
        tmp.font = TextFont;
        tmp.text = "HIT!";
        tmp.fontSize = 5;
        tmp.alignment = TextAlignmentOptions.Center;
        tmp.color = Color.green;

        yield return new WaitForSeconds(0.5f);
        Destroy(hitText);
    }

    public IEnumerator SpawnMiss()
    {
        GameObject missText = new GameObject("MissText");
        missText.transform.position = MissSpawn.position;

        TextMeshPro tmp = missText.AddComponent<TextMeshPro>();
        tmp.font = TextFont;
        tmp.text = "MISS!";
        tmp.fontSize = 5;
        tmp.alignment = TextAlignmentOptions.Center;
        tmp.color = Color.red;

        yield return new WaitForSeconds(0.5f);
        Destroy(missText);
    }
}
