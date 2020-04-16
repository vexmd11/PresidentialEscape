using UnityEngine;

public abstract class ObjectiveObject : MonoBehaviour
{

    public GoalType goalType;
    public bool isActive;
    public string title;
    public GameObject player;

    public ObjectiveObject(string title, bool isActive, GoalType goalType, GameObject player) {
        this.title = title;
        this.isActive = isActive;
        this.goalType = goalType;
        this.player = player;
    }

    public GoalType getGoalType() {
        return goalType;
    }

    public abstract bool isComplete();
}

public enum GoalType { 
    Gather,
    Destination
}