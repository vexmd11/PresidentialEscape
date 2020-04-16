using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Script for both the health and the stamina bar.
 */
public class UIBarScript : MonoBehaviour
{

    public GameObject player;
    public RectTransform transform;
    public bool healthbar; //boolean that is set in the inspector to dictate which variable it will keep track of (stamina or health)
    // Start is called before the first frame update
    float value, initialVal; //reflects the player's value that it's keeping track of
    void Start()
    {
        //set at the start. Used for comparison of player's health later on.
        if (healthbar)
        {
            initialVal = player.GetComponent<PlayerMovementScript>().health;
            value = initialVal;
        }
        else {
            initialVal = player.GetComponent<PlayerMovementScript>().stamina;
            value = initialVal;
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        if (healthbar && value > 0)
        {
            value = (float)player.GetComponent<PlayerMovementScript>().health;
            transform.localScale = new Vector2((value / initialVal) - .03f, .5f);
        }
        else if (!healthbar && value > 0) {
            value = (float)player.GetComponent<PlayerMovementScript>().stamina;
            transform.localScale = new Vector2((value / initialVal) - .03f, .5f);
        }


            




    }
}
