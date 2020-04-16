using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathImageScript : MonoBehaviour
{
    public GameObject player;
    public CanvasGroup deathCanvas;
    private float health;
    // Start is called before the first frame update
    void Start()
    {
        deathCanvas.alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        health = player.GetComponent<PlayerMovementScript>().health;

        if (health <= 0)
            deathCanvas.alpha = deathCanvas.alpha+((float).4*Time.deltaTime);

        if (deathCanvas.alpha == 1)
        {
            if (health <= 0) //this means player died
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else //this means player completed the level
            {
                GameData data = SaveSystem.loadData();

                if (data == null) //this means no save data on computer
                    SaveSystem.saveData(SceneManager.GetActiveScene().buildIndex + 1); //level is saved
                else { 
                    if (data.level <= SceneManager.GetActiveScene().buildIndex) //if current saved level index is less or equal to current level that is being played
                            SaveSystem.saveData(SceneManager.GetActiveScene().buildIndex + 1); //level is saved
                    //if current saved level is HIGHER than the current level being played, we dont want to overwrite the save data with a lower level
                }
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
            }
                  
        }
            
    }
}
