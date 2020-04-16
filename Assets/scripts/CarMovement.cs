using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarMovement : MonoBehaviour
{
    public bool hitPath = false;
    public bool hitEnd = false;
    public bool finished = false;
    bool changeRotation = false;
    public Rigidbody rb;
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    public GameObject completeLevelUI;

    Quaternion startRotation;
    Quaternion endRotation;
    float rotationProgress = -1;
    float yPos;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!hitPath)
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);

            if (Input.GetKey(KeyCode.D))
            {
                rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }

            if (Input.GetKey(KeyCode.A))
            {
                rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }

            yPos = transform.rotation.eulerAngles.y + 90;
        }
        else
        {
            if (!hitEnd)
            {
                StartRotating(yPos);

                if (rotationProgress < 1 && rotationProgress >= 0)
                {
                    rotationProgress += Time.deltaTime * 4;

                    // Here we assign the interpolated rotation to transform.rotation
                    // It will range from startRotation (rotationProgress == 0) to endRotation (rotationProgress >= 1)
                    transform.rotation = Quaternion.Lerp(startRotation, endRotation, rotationProgress);
                    rb.rotation = Quaternion.Lerp(startRotation, endRotation, rotationProgress);
                }

                rb.AddForce(forwardForce * Time.deltaTime, 0, 0);

                if (Input.GetKey(KeyCode.D))
                {
                    rb.AddForce(0, 0, -sidewaysForce * Time.deltaTime, ForceMode.VelocityChange);
                }

                if (Input.GetKey(KeyCode.A))
                {
                    rb.AddForce(0, 0, sidewaysForce * Time.deltaTime, ForceMode.VelocityChange);
                }
            }
            else
            {
                if (!finished)
                {
                    rb.AddForce(-forwardForce * 40 * Time.deltaTime, 0, 0);
                    finished = true;
                }
                else
                {
                    completeLevelUI.SetActive(true);
                    Invoke("BeginNextScene", 1.4f);
                }
                
            }

            
        }

    }

    // Call this to start the rotation
    void StartRotating(float yPosition)
    {

        // Here we cache the starting and target rotations
        startRotation = transform.rotation;
        endRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, yPosition, transform.rotation.eulerAngles.z);

        // This starts the rotation, but you can use a boolean flag if it's clearer for you
        rotationProgress = 0;
    }

    private void BeginNextScene()
    {
        GameData data = SaveSystem.loadData();

        if (data == null) //this means no save data on computer
            SaveSystem.saveData(SceneManager.GetActiveScene().buildIndex + 1); //level is saved
        else
        {
            if (data.level <= SceneManager.GetActiveScene().buildIndex) //if current saved level index is less or equal to current level that is being played
                SaveSystem.saveData(SceneManager.GetActiveScene().buildIndex + 1); //level is saved
            //if current saved level is HIGHER than the current level being played, we dont want to overwrite the save data with a lower level
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}
