using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatherObjectiveObject : ObjectiveObject
{
    public GameObject[] items;
    public int current;
    public int required;

    public GatherObjectiveObject(string title, bool isActive, GameObject player, GameObject[] items, int current, int required) : 
        base(title, isActive, GoalType.Gather, player)
    {
        //calls super constructor first
        this.items = items;
        this.current = current;
        this.required = required;
    }

     public override bool isComplete() {
        return required <= current;
    }

    public GameObject[] getItems() {
        return items;
    }
}
