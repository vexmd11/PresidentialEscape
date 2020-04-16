using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupController : MonoBehaviour
{
    float timeBetweenThrow = 8f;
    float throwPower = 10f;
    float timer = 0f;
    float spawnDistance = 2f;
    float timeAttracted = 4f;
    public int numPowerups = 1;
    public GameObject powerUp;
    private GameObject powerUpClone;
    Vector3 playerPos, spawnPos, playerDirection;
    Quaternion playerRotation;
    // Start is called before the first frame update
    void Start()
    {
        powerUpClone = null;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Q) && timer >= timeBetweenThrow && numPowerups > 0)
        {
            playerPos = transform.position;
            playerDirection = transform.forward; // direction player is facing
            playerRotation = transform.rotation;
            spawnPos = playerPos + playerDirection * spawnDistance;

            powerUpClone = Instantiate(powerUp, spawnPos, playerRotation);
            Rigidbody rb = powerUpClone.GetComponent<Rigidbody>();
            rb.AddForce(playerDirection * throwPower, ForceMode.Impulse);
            Debug.Log("Throw");
            timer = 0;
            numPowerups--;
        }
        else if (Input.GetKeyDown(KeyCode.Q) && timer < timeBetweenThrow){
            Debug.Log(timer - timeBetweenThrow + " seconds left.    " + numPowerups + " powerups left.");
        }

        if (powerUp != null && timer >= timeAttracted) {
            Destroy(powerUpClone);
        }

    }
}
