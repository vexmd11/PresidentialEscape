using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GiveObjectiveScript : MonoBehaviour
{
    public dynamic objective;
    public ObjectiveObject obj;
    public bool objectiveObtained;
    public List<SubtitleObject> clips;
    
    // Start is called before the first frame update
    void Start()
    {
        objective = obj;
        objectiveObtained = false;
        
        try {
            if (objective.goalType == GoalType.Gather)
                objective = (GatherObjectiveObject)objective;
            else if (objective.goalType == GoalType.Destination)
                objective = (DestinationObjectiveObject)objective;
        } catch (Exception e) {
            Debug.Log(e.Message);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!objectiveObtained && other.tag.Equals("Player"))
        {
            objective.player.GetComponent<PlayerObjectiveController>().objectives.Add(objective);
            objectiveObtained = true;
            objective.isActive = true;

            if (clips.Count != 0)
            {
                other.gameObject.GetComponent<AudioManager>().addSubtitles(clips);
            }

            if (objective.goalType == GoalType.Gather) //makes the items appear
            {
                for (int i = 0; i < objective.items.Length; i++)
                {
                    try
                    {
                        objective.items[i].GetComponent<Collider>().enabled = true;
                    }
                    catch (Exception e)
                    {
                        Debug.Log(e.Message);
                    }

                    try
                    {
                        objective.items[i].GetComponent<SphereCollider>().enabled = true; //for picking up the item
                    }
                    catch (Exception e)
                    {
                        Debug.Log(e.Message);
                    }

                    try
                    {
                        objective.items[i].GetComponent<MeshRenderer>().enabled = true;
                    }
                    catch (Exception e)
                    {
                        Debug.Log(e.Message);
                    }
                }
            }
        }
    }
}

public enum PersonType { 
    COMM,
    President
}
