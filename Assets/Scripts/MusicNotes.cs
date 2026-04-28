using UnityEngine;

public class MusicNotes : Rhythm
{
    Vector2 ScreenPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void SpawnNotes()
    {
        Vector2 viewPortPos  = new Vector2(0f, 1f);

        Vector2 WorldPos = Camera.main.ViewportToWorldPoint(viewPortPos);
    }

    // Update is called once per frame
    void Update()
    {
        
        /*if (nextIndex < notes.Length && notes[nextIndex] < SongPositionInBeats + beatsShownInAdvance)
            {
                Instantiate(MusicNotePrefab, new Vector3(0f, 10f, 0f), Quaternion.identity);

                //initialize the fields of the music note
                nextIndex++;
            }
        transform.position = Vector2.Lerp(
            SpawnPos,
            RemovePos,
            (beatsShownInAdvance - (beatofThisNote - SongPositionInBeats)) / beatsShownInAdvance
        );*/
    }
}
