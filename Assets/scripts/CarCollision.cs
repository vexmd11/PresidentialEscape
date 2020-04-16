using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarCollision : MonoBehaviour
{
    public CarMovement movement;
    public GameObject explosionEffect;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Invoke("Restart", 1f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Path Trigger")
        {
            FindObjectOfType<CarMovement>().hitPath = true;
        }else if (other.tag == "End Trigger")
        {
            FindObjectOfType<CarMovement>().hitEnd = true;
        }
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
