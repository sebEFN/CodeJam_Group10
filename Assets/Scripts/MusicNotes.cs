using UnityEngine;

public class MusicNotes : MonoBehaviour
{
    public float HitTime;
    public float noteTravelTime;
    public Transform target;

    private Rhythm rhythm;

    private Vector3 spawnPos;
    private Vector3 targetPos;

    void Start()
    {
        rhythm = Rhythm.instance;

        spawnPos = transform.position;

        if (target != null)
            targetPos = target.position;
    }

    void Update()
    {
        float songTime = rhythm.SongPosition;

        float spawnTime = HitTime - noteTravelTime;

        float progress = (songTime - spawnTime) / noteTravelTime;

        progress = Mathf.Clamp01(progress);

        transform.position = Vector3.Lerp(
            spawnPos,
            targetPos,
            progress
        );

        // Missed note cleanup
        if (songTime > HitTime + 0.5f)
        {
            NoteObject noteObject = GetComponent<NoteObject>();

            if (noteObject != null && noteObject.canBePressed)
            {
                GameManager.instance.NoteMissed();
            }

            Destroy(gameObject);
        }
    }
}