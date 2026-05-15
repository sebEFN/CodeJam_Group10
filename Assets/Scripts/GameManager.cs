using JetBrains.Annotations;
using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

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
        StartCoroutine("SpawnHit");
    }
     public void NoteMissed()
    {
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
        tmp.fontSize = 4;
        tmp.alignment = TextAlignmentOptions.Center;
        tmp.color = Color.green;

        float elapsed = 0f;
        float duration = 0.5f;
        Vector3 startPos = HitSpawn.position;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            hitText.transform.position = startPos + Vector3.up * elapsed;
            yield return null;
        }
        Destroy(hitText);
    }

    public IEnumerator SpawnMiss()
    {
        GameObject missText = new GameObject("MissText");
        missText.transform.position = MissSpawn.position;

        TextMeshPro tmp = missText.AddComponent<TextMeshPro>();
        tmp.font = TextFont;
        tmp.text = "MISS!";
        tmp.fontSize = 4;
        tmp.alignment = TextAlignmentOptions.Center;
        tmp.color = Color.red;

        float elapsed = 0f;
        float duration = 0.5f;
        Vector3 startPos = MissSpawn.position;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            missText.transform.position = startPos + Vector3.up * elapsed;
            yield return null;
        }
        Destroy(missText);
    }
}
