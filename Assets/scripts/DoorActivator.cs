using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorActivator : MonoBehaviour
{
    public GameObject[] doors = new GameObject[4];
    public GatherObjectiveObject objective;
    private bool isComplete, hasChecked = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isComplete = objective.isComplete();
        if (isComplete && !hasChecked) {

            doors[0].GetComponent<MeshRenderer>().enabled = false;
            doors[0].GetComponent<BoxCollider>().enabled = false;
            doors[1].GetComponent<MeshRenderer>().enabled = false;
            doors[1].GetComponent<BoxCollider>().enabled = false;
            doors[2].GetComponent<MeshRenderer>().enabled = true;
            doors[2].GetComponent<BoxCollider>().enabled = true;
            doors[3].GetComponent<MeshRenderer>().enabled = true;
            doors[3].GetComponent<BoxCollider>().enabled = true;
            hasChecked = true;
        }
    }
}
