using UnityEngine;

public class MusicNotes : MonoBehaviour
{
    public float HitTime;
    public float noteTravelTime;

    public Transform target;

    public int lane;

    public bool wasHit = false;

    private Rhythm rhythm;

    private Vector3 spawnPos;
    private Vector3 targetPos;

    void Start()
    {
        rhythm = FindObjectOfType<Rhythm>();

        spawnPos = transform.position;

        if (target != null)
        {
            targetPos = target.position;
        }
    }

    void Update()
    {
        float songTime = rhythm.SongPosition;

        float spawnTime = HitTime - noteTravelTime;

        float progress = (songTime - spawnTime) / noteTravelTime;

        progress = Mathf.Clamp01(progress);

        if (target != null)
        {
            targetPos = target.position;
        }

        transform.position = Vector3.Lerp(
            spawnPos,
            targetPos,
            progress
        );

        // Missed note
        if (!wasHit && songTime > HitTime + 0.15f)
        {
            Debug.Log("Miss");

            Destroy(gameObject);
        }
    }

    public void Hit()
    {
        wasHit = true;

        Destroy(gameObject);
    }
}