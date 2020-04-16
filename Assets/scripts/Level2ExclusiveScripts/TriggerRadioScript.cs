using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRadioScript : MonoBehaviour
{
    public GatherObjectiveObject nextObjective;
    private bool isComplete;
    private bool hasGiven = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isComplete = this.GetComponent<GatherObjectiveObject>().isComplete();

        if (isComplete && !hasGiven) {
            Debug.Log(isComplete);
            GameObject.FindWithTag("Player").GetComponent<PlayerObjectiveController>().objectives.Add(nextObjective);
            nextObjective.GetComponent<GatherObjectiveObject>().isActive = true;
            //nextObjective.GetComponent<GatherObjectiveObject>().enabled = true;
            hasGiven = true;
            for (int i = 0; i < nextObjective.items.Length; i++) {

                nextObjective.items[i].GetComponent<SphereCollider>().enabled = true;
            }

        }
            
    }
}
