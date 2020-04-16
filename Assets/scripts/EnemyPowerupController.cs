using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPowerupController : MonoBehaviour
{
    GameObject powerup;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        powerup = GameObject.FindWithTag("Powerup");

        if (powerup != null)
        {
            GetComponent<AgentController>().player = powerup.GetComponent<Transform>();
        }
        else {
            GetComponent<AgentController>().player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
    }
}
