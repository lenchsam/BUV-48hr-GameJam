using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    // Reference to the RandomPlacer script
    public PlacePlastic randomPlacer;

    // Update is called once per frame
    void Update()
    {
        if (randomPlacer.closestObject != null)
        {
            // Get the direction to the closest object
            Vector3 direction = (randomPlacer.closestObject.transform.position - transform.position).normalized;

            // Calculate the target rotation to make the cylinder lie on its side and point towards the target
            Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up) * Quaternion.Euler(90, 0, 0);

            // Apply the rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 2.0f); // Adjust the 2.0f for the desired rotation speed
        }
    }
}
