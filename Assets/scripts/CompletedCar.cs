using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompletedCar : MonoBehaviour
{
    public ObjectiveObject tires;
    public ObjectiveObject Gas;
    public ObjectiveObject wrench;
    public GatherObjectiveObject repairCar;
    private bool triggered =false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tires.isComplete() && Gas.isComplete() && wrench.isComplete() && !triggered) {
            repairCar.isActive = true;
            GameObject.FindWithTag("Player").GetComponent<PlayerObjectiveController>().objectives.Add(repairCar);
            triggered = true;
            for (int i = 0; i < repairCar.items.Length; i++) {

                repairCar.items[i].GetComponent<SphereCollider>().enabled = true;

            }
        }
    }
}
