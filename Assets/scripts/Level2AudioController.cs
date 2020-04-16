using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level2AudioController : MonoBehaviour
{
    public List<SubtitleObject> clips;
    private AudioSource source;
    private SubtitleObject currentClip;
    public Text subtitles;

    private void Start()
    {
        source = this.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!source.isPlaying)
            subtitles.text = "";
        else if (currentClip != null)
            subtitles.text = currentClip.subtitle;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Audio1")
        {
            source.clip = clips[0].audio;
            subtitles.text = clips[0].personTalking.ToString() + ": " + clips[0].subtitle;
            source.Play();
            currentClip = clips[0];
        }
        else if (collider.tag == "Audio2")
        {
            source.clip = clips[1].audio;
            subtitles.text = clips[1].personTalking.ToString() + ": " + clips[1].subtitle;
            source.Play();
            currentClip = clips[1];
        }
        else if (collider.tag == "Audio3")
        {
            source.clip = clips[2].audio;
            subtitles.text = clips[2].personTalking.ToString() + ": " + clips[2].subtitle;
            source.Play();
            currentClip = clips[2];
        }
        else if (collider.tag == "Audio4")
        {
            source.clip = clips[3].audio;
            subtitles.text = clips[3].personTalking.ToString() + ": " + clips[3].subtitle;
            source.Play();
            currentClip = clips[3];
        }
        else if (collider.tag == "Audio5")
        {
            source.clip = clips[4].audio;
            subtitles.text = clips[4].personTalking.ToString() + ": " + clips[4].subtitle;
            source.Play();
            currentClip = clips[4];
        }
        else if (collider.tag == "Audio6")
        {
            source.clip = clips[5].audio;
            subtitles.text = clips[5].personTalking.ToString() + ": " + clips[5].subtitle;
            source.Play();
            currentClip = clips[5];
        }
        else if (collider.tag == "Audio7")
        {
            source.clip = clips[6].audio;
            subtitles.text = clips[6].personTalking.ToString() + ": " + clips[6].subtitle;
            source.Play();
            currentClip = clips[6];
        }
    }
}
