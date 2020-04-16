using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{

    public Transform player;
    NavMeshAgent agent;
    private bool seenPlayer = false;
    public float range = 20f;
    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (seenPlayer)
        {
            agent.SetDestination(player.position);
        }

        Vector3 playerDir = player.position - transform.position;
        float angle = Vector3.Angle(playerDir, transform.forward);

        if (angle < 60.0f) {
            RaycastHit look;
            if (!seenPlayer) {
                if (Physics.Raycast(transform.position, (player.position - transform.position), out look, range))
                {
                    //player can be seen from the raycast

                    if (look.transform == player)
                    {
                        seenPlayer = true;
                        //ignore raycasts after you see the player
                        gameObject.layer = 2;
                    }
                }
            }

        }
    }
}
