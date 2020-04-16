using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject levelSelectUI;
    private int level;
    private Button[] buttons;

    public void Start()
    {
        /* UNCOMMENT THIS TO IMPLEMENT THE SELECTING LEVELS PROPERLY
        GameData g = SaveSystem.loadData();
        if (g != null)
        {
            level = g.level;
        }
        else
            level = 1;

        buttons = levelSelectUI.GetComponentsInChildren<Button>();

        for (int i = 0; i < buttons.Length; i++)
        {
                buttons[i].interactable = false;
        }

        for (int i = 0; i < level; i++) {
            buttons[i].interactable = true;
        }
        */
    }

    public void StartTutorial()
    {
            SceneManager.LoadScene(1);
    }

    public void StartZuZuCity()
    {
            SceneManager.LoadScene(2);
    }

    public void StartRockyRoad()
    {
            SceneManager.LoadScene(3);
    }

    public void StartCindersapForest()
    {   
            SceneManager.LoadScene(4);
    }

    public void StartTumblyTrail()
    {   
            SceneManager.LoadScene(5);
    }

    public void Back()
    {
        levelSelectUI.SetActive(false);
        mainMenuUI.SetActive(true);        
    }
}
