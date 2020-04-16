using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinGrab : MonoBehaviour
{
    public Text scoreText;
    public static int score = 0;
    public List<SubtitleObject> clips;
    public AudioClip coinSound;
    private bool collected = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (!collected) {
                Destroy(gameObject);
                score += 100;
                if (score == 100)
                    GameObject.FindWithTag("Player").GetComponent<AudioManager>().addSubtitles(clips);
                //this makes it so that the subtitle on the UI does not glitch out by adding sounds tothe players audio manager, we just play it at the coins position
                AudioSource.PlayClipAtPoint(coinSound, this.transform.position);
                scoreText.text = "Score: " + score;
                collected = false;
            }
                    
        }
    }
}
