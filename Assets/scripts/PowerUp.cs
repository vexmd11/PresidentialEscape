using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject pickupEffect;
    public float multiplier = 1.4f;
    public float duration = 4f;
    public int numToGive = 1;
    private bool isPickedUp = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isPickedUp)
        {
            isPickedUp = true;
            Pickup(other);
            other.GetComponent<PowerupController>().numPowerups += numToGive;
        }
    }

    void Pickup(Collider player)
    {
        //instantiate particle effect
        Instantiate(pickupEffect, transform.position, transform.rotation);

        //destroy powerup
        Destroy(gameObject);
    }
}
