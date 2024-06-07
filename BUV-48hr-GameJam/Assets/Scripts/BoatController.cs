using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    [SerializeField] private float acceleration = 5f; // Acceleration rate
    [SerializeField] private float deceleration = 2f; // Deceleration rate
    [SerializeField] private float maxSpeed = 20f; // Maximum speed
    [SerializeField] private float continueTime = 1f; // Time to continue after releasing acceleration
    [SerializeField] private  float turnSpeed = 50f; // Turning speed
    [SerializeField] private float brakeDeceleration = 10f; // Deceleration rate when braking

    [SerializeField] private float currentSpeed = 0f; // Current speed of the car
    [SerializeField] private float continueCounter = 0f; // Counter for continuing movement

    void Update()
    {
        // Check if the player is pressing the acceleration key (W or Up arrow)
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            // Accelerate the car
            currentSpeed += acceleration * Time.deltaTime;
            continueCounter = continueTime; // Reset the continue counter
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            // Decelerate the car actively when pressing the brake key
            currentSpeed -= brakeDeceleration * Time.deltaTime;
            continueCounter = 0f; // Reset the continue counter to stop any continuation
        }
        else
        {
            // If the player releases the acceleration key, continue moving for a short time
            if (continueCounter > 0)
            {
                continueCounter -= Time.deltaTime;
            }
            else
            {
                // Decelerate the car gradually
                currentSpeed -= deceleration * Time.deltaTime;
            }
        }

        // Clamp the speed to the maximum speed
        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);

        // Turning the car
        if (currentSpeed > 0)
        {
            float turnDirection = 0f;
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                turnDirection = -1f; // Turn left
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                turnDirection = 1f; // Turn right
            }

            // Apply the turning
            transform.Rotate(Vector3.up, turnDirection * turnSpeed * Time.deltaTime);
        }

        // Move the car forward
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
    }
}
