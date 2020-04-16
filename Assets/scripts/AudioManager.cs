using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{

    private AudioSource source;
    private List<SubtitleObject> clips;
    private SubtitleObject currentClip;
    public Text subtitleUI;

    // Start is called before the first frame update
    void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
        clips = new List<SubtitleObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!source.isPlaying)
        { //clip is done playing
            subtitleUI.text = "";
            if (currentClip != null)
                currentClip.setClipDone(true);
        }

        for (int i = 0; i < clips.Count; i++) {
            //Debug.Log(clips[i].subtitle + "has played: " + clips[i].hasPlayed());
            if (clips[i] != null && clips[i].hasPlayed()) //removes clip from list if has played
                clips.Remove(clips[i]);
            if (clips.Count != 0 && clips[i] != null && !source.isPlaying && !clips[i].hasPlayed()) {
                if (!PauseMenu.gameIsPaused)
                {
                    subtitleUI.text = clips[i].personTalking.ToString() + ": " + clips[i].subtitle;
                    clips[i].setClipPlaying(true);
                    source.clip = clips[i].audio;
                    source.Play();
                    currentClip = clips[i];
                }
                break;
            }
        }

        if (source.isPlaying && currentClip != null)
        {
            subtitleUI.text = currentClip.personTalking.ToString() + ": " + currentClip.subtitle;
        }
    }

    public void setSubtitles(List<SubtitleObject> clips) {
        this.clips = clips;
    }

    public void addSubtitles(List<SubtitleObject> clips) {
        for (int i = 0; i < clips.Count; i++)
            this.clips.Add(clips[i]);
    }

    public List<SubtitleObject> getSubList() {
        return clips;
    }
}
