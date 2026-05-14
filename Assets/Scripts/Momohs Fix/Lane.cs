using Melanchall.DryWetMidi.Interaction;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lane : MonoBehaviour
{
    public Melanchall.DryWetMidi.MusicTheory.NoteName noteRestriction;
    bool tappedThisFrame = false;
    public GameObject notePrefab;
    List<Note> notes = new List<Note>();
    public List<double> timeStamps = new List<double>();

    int spawnIndex = 0;
    int inputIndex = 0;

    void Start()
    {

    }

    void TryHit()
    {
        if (inputIndex < timeStamps.Count)
        {
            double timeStamp = timeStamps[inputIndex];
            double marginOfError = SongManager.Instance.marginOfError;
            double audioTime = SongManager.GetAudioSourceTime() - (SongManager.Instance.inputDelayInMilliseconds / 1000.0);

            if (Math.Abs(audioTime - timeStamp) < marginOfError)
            {
                Hit();
                print($"Hit on {inputIndex} note");
                if (inputIndex < notes.Count && notes[inputIndex] != null)
                    Destroy(notes[inputIndex].gameObject);
                inputIndex++;
            }
            else
            {
                print($"Hit inaccurate on {inputIndex} note wih {Math.Abs(audioTime - timeStamp)} delay");
            }
        }
    }

    public void OnTap()
    {
        if (!tappedThisFrame)
        {
            tappedThisFrame = true;
            print("Lane tapped:" + gameObject.name);
            TryHit();
        }
    }
    public void SetTimeStamps(Melanchall.DryWetMidi.Interaction.Note[] array)
    {
        foreach (var note in array)
        {
            if (note.NoteName == noteRestriction)
            {
                var metricTimeSpan = TimeConverter.ConvertTo<MetricTimeSpan>(note.Time, SongManager.midiFile.GetTempoMap());
                timeStamps.Add((double)metricTimeSpan.Minutes * 60f + metricTimeSpan.Seconds + (double)metricTimeSpan.Milliseconds / 1000f);
            }
        }
    }

    void Update()
    {
        tappedThisFrame = false;

        if (spawnIndex < timeStamps.Count)
        {
            if (SongManager.GetAudioSourceTime() >= timeStamps[spawnIndex] - SongManager.Instance.noteTime)
            {
                var note = Instantiate(notePrefab, transform);
                notes.Add(note.GetComponent<Note>());
                note.GetComponent<Note>().assignedTime = (float)timeStamps[spawnIndex];
                spawnIndex++;
            }
        }

        if (inputIndex < timeStamps.Count)
        {
            double timeStamp = timeStamps[inputIndex];
            double marginOfError = SongManager.Instance.marginOfError;
            double audioTime = SongManager.GetAudioSourceTime() - (SongManager.Instance.inputDelayInMilliseconds / 1000.0);

            if (timeStamp + marginOfError <= audioTime)
            {
                Miss();
                print($"Missed {inputIndex} note");
                inputIndex++;
            }
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Vector2 pos = Camera.main.ScreenToWorldPoint(touch.position);
                RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

                if (hit.collider != null)
                {
                    hit.collider.GetComponentInParent<Lane>()?.OnTap();
                }
            }
        }
    }

    private void Miss()
    {
        ScoreManager.Miss();
    }

    private void Hit()
    {
        ScoreManager.Hit();
    }
}