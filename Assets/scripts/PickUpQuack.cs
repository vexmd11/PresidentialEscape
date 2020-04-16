using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpQuack : MonoBehaviour
{
    private bool inRadius = false;
    public AudioClip quackSFX;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && inRadius)
        {
            AudioSource.PlayClipAtPoint(quackSFX, this.gameObject.transform.position);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            inRadius = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") {
            inRadius = false;
        }
    }
}
