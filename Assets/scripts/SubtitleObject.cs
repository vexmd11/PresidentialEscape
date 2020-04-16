using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SubtitleObject
{
    public PersonType personTalking;
    public string subtitle;
    public AudioClip audio;
    private bool isPlaying = false;
    private bool played = false;

    public bool hasPlayed() {
        return played;
    }

    public bool isClipPlaying() {
        return isPlaying;
    }

    public void setClipPlaying(bool playing) {
        this.isPlaying = playing;
    }

    public void setClipDone(bool isDone) {
        this.played = isDone;
    }
}
