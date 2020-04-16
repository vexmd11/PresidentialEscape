using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectiveManagerScript : MonoBehaviour
{
    public GoalType goaltype;
    public ObjectiveObject obj;
    public dynamic objective;
    public List<SubtitleObject> dialogueWhenComplete;
    
    // Start is called before the first frame update
    void Start()
    {
        objective = obj;
        if (goaltype == GoalType.Gather)
        {
            objective = (GatherObjectiveObject)objective; //type cast for polymorphism heh

            for (int i = 0; i < objective.items.Length; i++) //makes items invisible, uncollidable until objective is obtained
            {
                try
                {
                    objective.items[i].GetComponent<Collider>().enabled = false;
                }
                catch (Exception e) {
                    Debug.Log(e.Message);
                }

                try
                {
                    objective.items[i].GetComponent<SphereCollider>().enabled = false; //for picking up the item
                }
                catch (Exception e) {
                    Debug.Log(e.Message);
                }

                try
                {
                    objective.items[i].GetComponent<MeshRenderer>().enabled = false;
                }
                catch (Exception e) {
                    Debug.Log(e.Message);
                }
            }

        }
        else if (goaltype == GoalType.Destination)
        {
            objective = (DestinationObjectiveObject)objective;
            objective.gameObject.transform.localScale = new Vector3(2 * objective.destinationRadius, 
                2 * objective.destinationRadius, 2 * objective.destinationRadius); //sizes up the collider to specified radius
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (objective.isActive && objective.goalType == GoalType.Gather) //ONLY IF OBJECTIVE IS GATHERING
        {
            objective.current = 0;
            for (int i = 0; i < objective.items.Length; i++)
            {
                if (objective.items[i] == null)
                    objective.current++; //this means we found the part and the part is now destroyed from the scene
            }
            //updates current to reflect the number of items we have
        }

        if (objective.isActive && objective.isComplete()) {
            GameObject.FindWithTag("Player").GetComponent<AudioManager>().addSubtitles(dialogueWhenComplete);
            objective.player.GetComponent<PlayerObjectiveController>().objectives.Remove(objective);
            objective.isActive = false;
        }
    }
}
