using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject resumeButton;
    public GameObject camera;
    public GameObject player;

    void Start()
    {
        pauseMenuUI.SetActive(false);
        AudioListener.volume = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        camera.GetComponent<MouseLook>().enabled = true;
        pauseMenuUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        gameIsPaused = false;

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            player.GetComponentInChildren<AudioSource>().UnPause();
        }
        else
        {
            player.GetComponent<AudioSource>().UnPause();
        }

        AudioListener.volume = 1;
    }

    void Pause()
    {
        camera.GetComponent<MouseLook>().enabled = false;
        pauseMenuUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        gameIsPaused = true;

        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            player.GetComponentInChildren<AudioSource>().Pause();
        }
        else
        {
            player.GetComponent<AudioSource>().Pause();
        }

        AudioListener.volume = 0;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        gameIsPaused = false;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

