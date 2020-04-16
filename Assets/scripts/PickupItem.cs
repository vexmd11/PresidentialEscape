using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupItem : MonoBehaviour
{
    public GameObject pickupItemMenu;
    public string message;
    private const string DEFAULTMSG = "Press \'F\' to pick up";
    private bool inRadius = false;
    private bool itemPickedUp = false;
    public List<SubtitleObject> clips;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && inRadius)
        {
            itemPickedUp = true;
            Destroy(gameObject);

            if (clips.Count != 0) //audio clips
            {
                GameObject.FindWithTag("Player").GetComponent<AudioManager>().addSubtitles(clips);
            }

            if (inRadius)
            {
                pickupItemMenu.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            if (message.Equals(""))
                pickupItemMenu.GetComponentInChildren<Text>().text = DEFAULTMSG;
            else
                pickupItemMenu.GetComponentInChildren<Text>().text = message;
            pickupItemMenu.SetActive(true);
            inRadius = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            pickupItemMenu.SetActive(false);
            inRadius = false;
        }
    }
}
