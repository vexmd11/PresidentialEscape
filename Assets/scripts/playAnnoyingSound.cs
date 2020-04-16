using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAnnoyingSound : MonoBehaviour
{

    public AudioClip sound;
    public GatherObjectiveObject objective;
    private bool complete;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        complete = objective.isComplete();

        if (complete) {
            if (this.GetComponent<AudioSource>().isPlaying == false)
                this.GetComponent<AudioSource>().PlayOneShot(sound);
        }
        
    }
}
