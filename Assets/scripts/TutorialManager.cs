using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    private bool audioIsPlaying;
    public List<SubtitleObject> Dialogue1;
    private bool Dialogue1Added = false;
    public List<SubtitleObject> Dialogue2;
    private bool Dialogue2Added = false;
    public List<SubtitleObject> Dialogue3;
    private bool Dialogue3Added = false;
    private bool wallDestroyed = false;
    public GameObject wall;
    private bool noClipsInQueue;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindWithTag("Player").GetComponent<PowerupController>().numPowerups = 0;
    }

    // Update is called once per frame
    void Update()
    {
        audioIsPlaying = GetComponent<AudioSource>().isPlaying;
        noClipsInQueue = GetComponent<AudioManager>().getSubList().Count == 0;


        if (!Dialogue1Added && !audioIsPlaying)
        {
            GetComponent<AudioManager>().addSubtitles(Dialogue1);
            Dialogue1Added = true;
        }
        else if (Dialogue1Added && !Dialogue2Added && !audioIsPlaying && (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S)
            || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W)))
        {
            GetComponent<PlayerMovementScript>().enabled = true;
            GetComponent<AudioManager>().addSubtitles(Dialogue2);
            Dialogue2Added = true;
        }
        else if (!wallDestroyed && !audioIsPlaying && Dialogue2Added && noClipsInQueue) {
            Destroy(wall);
            wallDestroyed = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Autograph" && !Dialogue3Added)
        {
            GetComponent<AudioManager>().addSubtitles(Dialogue3);
            Dialogue3Added = true;
        }
        else if (other.tag == "Finish")
        {
            SaveSystem.saveData(SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
