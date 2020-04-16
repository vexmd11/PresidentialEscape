using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerObjectiveController : MonoBehaviour
{
    public List<dynamic> objectives = new List<dynamic>();
    public Text objectiveText;


    // Update is called once per frame
    void Update()
    {
        displayObjectives();
    }

    private void displayObjectives() 
    {
        string text = "Current Objectives: \n";
        for (int i = 0; i < objectives.Count; i++)
        {
            if (objectives[i].goalType == GoalType.Gather) //gather objective
            { 
                text += "    " + objectives[i].title + " (" + objectives[i].current.ToString()
                     + "/" + objectives[i].required.ToString() + ")" + "\n"; //displays parts
            }
            else //other objectives just display title
                text += "    " + objectives[i].title + "\n";
        }
        objectiveText.text = text;
    }
}
