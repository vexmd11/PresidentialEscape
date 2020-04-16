using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimatedAgent : MonoBehaviour
{

    public Transform player;
    public Transform[] points; //array of points for the enemy to walk to
    public AudioClip[] phrases; //lets arbitrarily say that phrases 1-2 are when they're by themselves. 3-n are when they see the player.
    public GameObject powerup;

    private float speed;
    public int audioBuffer;
    public int timeDifference;
    Animator animator;
    NavMeshAgent agent;
    private bool seenPlayer = false;
    public float range = 20f;
    bool colliding = false;
    bool atPoint = false;
    int pointNum = 0;
    private bool mover = false; //dictates if this agent is meant to stay still or move around if they don't see the player
    // Start is called before the first frame update

    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        speed = agent.speed;
        //slightly changing the buffer between phrases. That way everyone isn't talking at the same time.
        audioBuffer = audioBuffer + Random.Range(-timeDifference, timeDifference);

        if (points.Length == 0)
            mover = false;
        else
            mover = true;

        //if they're walking from point to point, they will move slower.
        if (mover)
            agent.speed = speed / 2;
    }

    // Update is called once per frame
    void Update()
    {

        //play sound clips
        if (audioBuffer > 0)
            audioBuffer--;
        else if (audioBuffer <= 0){
            if (!seenPlayer)
            {
                int clipNum = Random.Range(0, 2);
                playClip(clipNum);
                audioBuffer = 500 + Random.Range(-timeDifference, timeDifference);
            }
            else {
                int clipNum = Random.Range(3, 5);
                playClip(clipNum);
                audioBuffer = 250 + Random.Range(-timeDifference, timeDifference); ;
            }
            
            
        }
            




        if (mover)
        {
            if (!seenPlayer && !atPoint)
            {
                agent.SetDestination(points[pointNum].position);
                animator.SetFloat("Velocity", 1);

            }

            if (!atPoint && Vector3.Distance(points[pointNum].position, transform.position) < 3)
            {
                atPoint = true;
                //Debug.Log("atPoint" + pointNum);
                animator.SetFloat("Velocity", -1);
                if (pointNum + 1 < points.Length)
                {
                    pointNum++;
                    //Debug.Log("incrementing");
                }
                else
                {
                    pointNum = 0;
                }

                atPoint = false;



            }

        }
        

        //changing the animation depending on if they're colliding with the player
        if (seenPlayer && !colliding)
        {
            animator.SetFloat("Velocity", 1);
            agent.SetDestination(player.position);
        }
        else if (seenPlayer && colliding) {
            animator.SetFloat("Velocity", -1);
            agent.SetDestination(transform.position);
        }

        Vector3 playerDir = player.position - transform.position;
        float angle = Vector3.Angle(playerDir, transform.forward);

        if (angle < 60.0f)
        {
            RaycastHit look;
            if (!seenPlayer)
            {
                if (Physics.Raycast(transform.position, (player.position - transform.position), out look, range))
                {
                    //player can be seen from the raycast
                    if (look.transform == player)
                    {
                        seenPlayer = true;

                        //instantly say something once you've seen the player.
                        audioBuffer = 0;

                        if (mover)
                            agent.speed = speed; //setting speed back to normal.

                        mover = false; //will no longer want to find points to move to.
                        //ignore raycasts after you see the player
                        gameObject.layer = 2;
                    }
                }
            }

        }

        /*
         * Distraction power up
         * 
         */

        powerup = GameObject.FindWithTag("Powerup");

        if (powerup != null && seenPlayer)
        {
            agent.SetDestination(powerup.GetComponent<Transform>().position);
        }
        else if (powerup == null && seenPlayer)
        {
            agent.SetDestination(player.position);
        }
    }

    void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.tag.Equals("Player") && seenPlayer) {
            colliding = true;
        }
    }
    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag.Equals("Player") && seenPlayer)
        
        {
            colliding = false;
        }

        
    }
    public void playClip(int clipNum) {
        //Debug.Log("PLAYING CLIP " + clipNum);
        GetComponent<AudioSource>().PlayOneShot(phrases[clipNum], .3f);
    }
}
