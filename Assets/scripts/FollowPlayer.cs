using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    bool changed = false;
    private Vector3 newRotation;

    Quaternion startRotation;
    Quaternion endRotation;
    float rotationProgress = -1;
    float yPos;

    // Update is called once per frame
    void Update()
    {
        if (!FindObjectOfType<CarMovement>().hitPath)
        {
            transform.position = player.position + offset;
            yPos = transform.rotation.eulerAngles.y + 90;
            
        }
        else
        {
            if (!changed)
            {
                offset = new Vector3(-5, 2, 0);
                changed = true;
            }
            StartRotating(yPos);

            if (rotationProgress < 1 && rotationProgress >= 0)
            {
                rotationProgress += Time.deltaTime * 8;

                // Here we assign the interpolated rotation to transform.rotation
                // It will range from startRotation (rotationProgress == 0) to endRotation (rotationProgress >= 1)
                transform.rotation = Quaternion.Lerp(startRotation, endRotation, rotationProgress);
            }

            transform.position = player.position + offset;
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
}
