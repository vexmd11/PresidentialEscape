using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DestinationObjectiveObject : ObjectiveObject
{
    public float destinationRadius;
    private bool arrived = false;

    public DestinationObjectiveObject(string title, bool isActive, GameObject player, float destinationRadius) :
        base(title, isActive, GoalType.Destination, player)
    {
        //calls super constructor first
    }

    public override bool isComplete()
    {
        return arrived;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isActive && !arrived && other.tag.Equals("Player"))
        {
            arrived = true;
        }
    }
}
