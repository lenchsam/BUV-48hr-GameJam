using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    public float acceleration = 10f; // Fast acceleration rate for arcade feel
    public float deceleration = 5f; // Quick deceleration rate
    public float maxSpeed = 30f; // Higher maximum speed for the boat
    public float continueTime = 0.5f; // Shorter time to continue after releasing acceleration
    public float turnSpeed = 100f; // Fast turning speed for arcade feel
    public float brakeDeceleration = 15f; // Fast deceleration rate when braking
    public float driftTurnSpeed = 150f; // Increased turning speed when holding S
    public float driftFactor = 0.95f; // Factor to apply to drift movement

    private float currentSpeed = 0f; // Current speed of the boat
    private float continueCounter = 0f; // Counter for continuing movement
    private bool isDrifting = false; // Flag to indicate if the boat is drifting

    void Update()
    {
        // Check if the player is pressing the acceleration key (W or Up arrow)
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            // Accelerate the boat
            currentSpeed += acceleration * Time.deltaTime;
            continueCounter = continueTime; // Reset the continue counter
            isDrifting = false; // Reset drifting flag
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            // If accelerating and pressing the brake key, start drifting
            if (currentSpeed > 0)
            {
                isDrifting = true;
            }
            else
            {
                // Decelerate the boat actively when pressing the brake key without acceleration
                currentSpeed -= brakeDeceleration * Time.deltaTime;
                continueCounter = 0f; // Reset the continue counter to stop any continuation
            }
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
                // Decelerate the boat gradually
                currentSpeed -= deceleration * Time.deltaTime;
            }
        }

        // Clamp the speed to the maximum speed
        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);

        // Turning the boat
        float turnDirection = 0f;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            turnDirection = -1f; // Turn left
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            turnDirection = 1f; // Turn right
        }

        if (currentSpeed > 0)
        {
            // Apply the turning, modify turning while drifting for more dramatic effect
            float turnSpeedModifier = isDrifting ? driftTurnSpeed : turnSpeed;
            transform.Rotate(Vector3.up, turnDirection * turnSpeedModifier * Time.deltaTime);
        }

        // Move the boat forward
        Vector3 forwardMovement = transform.forward * currentSpeed * Time.deltaTime;
        if (isDrifting)
        {
            // Apply sideways drift movement without reducing speed
            Vector3 driftMovement = transform.right * turnDirection * currentSpeed * driftFactor * Time.deltaTime;
            transform.position += forwardMovement + driftMovement;
        }
        else
        {
            transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
        }
    }
}
