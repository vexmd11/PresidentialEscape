using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Player script for movement. Horizontal and vertical movement is done during the regular update, while physics-based jumping is done in fixed update
 */
public class PlayerMovementScript : MonoBehaviour
{

    public CharacterController controller;
    public float speed = 7f;
    private float initialSpeed;
    public float runSpeed;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHeight = 3f;
    Vector3 velocity;
    bool isGrounded;

    public float health;
    public int stamina;
    private float initialHealth;
    private int initialStamina;
    bool exhausted = false;
    bool shoved = false;
    // Start is called before the first frame update
    void Start()
    {
        initialSpeed = speed;
        initialHealth = health;
        initialStamina = stamina;
        //runSpeed = initialSpeed + 3.5f;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        //change to getbuttondown later. Couldn't add leftshift in there
        //general input for running
      
        //if the player is pressing shift while walking left, right, up or down while not being exausted.
        if (Input.GetKey(KeyCode.LeftShift) && stamina > 20 && !exhausted && (x != 0 || z != 0))
        {
            speed = runSpeed;
            stamina--;

            if (stamina <= 20)
                exhausted = true;

        }
        //if they're not holding onto shift or their exhausted
        else if (!Input.GetKey(KeyCode.LeftShift) || exhausted) {
            speed = initialSpeed;
            //Debug.Log("RECOVERING");
            if (stamina < initialStamina)
                stamina++;
            if (exhausted && stamina == initialStamina)
                exhausted = false;
        }

        if (shoved) {
            speed = initialSpeed-2;
        }

        
        if (isGrounded && velocity.y < 0)
        {
            controller.slopeLimit = 45f;
            velocity.y = -10f;
            
        }
        
        //based on our movement input and the direction the player is moving, it moves the player.
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move*speed*Time.deltaTime);
        
    }
    private void FixedUpdate()
    {
        //if player colides with anything in the ground mask, it is on the ground.
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            controller.slopeLimit = 100f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void OnTriggerStay(Collider enemy)
    {
        if (enemy.transform.gameObject.tag == "enemy") {
            health-=1*Time.deltaTime;
            shoved = true;
        }
    }

    private void OnTriggerExit(Collider enemy)
    {
        shoved = false;
    }
}
