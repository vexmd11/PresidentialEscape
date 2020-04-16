using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class EndLevel : MonoBehaviour
{
    private List<SubtitleObject> clips;    // Start is called before the first frame update
    private ObjectiveObject end;
    public CanvasGroup endImage;
    void Start()
    {
        try
        {
            end = this.GetComponent<GatherObjectiveObject>();
        }
        catch (Exception e)
        {
            Debug.Log("No gather objective on this object, getting destination objective instead for end game");
        }
        finally {
            if (end == null)
                end = this.GetComponent<DestinationObjectiveObject>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        clips = GameObject.FindWithTag("Player").GetComponent<AudioManager>().getSubList();
        if (end.isComplete() && clips.Count == 0) { //when objective is complete and no dialogue is playing, starts the end image sequence, saving handled by DeathImage script
            endImage.alpha = endImage.alpha + ((float).4 * Time.deltaTime);
        }
    }
}
