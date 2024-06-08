using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f; // Initial health value

    void OnTriggerEnter(Collider other)
    {
        // Check if the collision is with an environment object
        if (other.gameObject.CompareTag("Enviroment"))
        {
        TakeDamage(10f); // Amount of damage to take on collision
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("Health: " + health);

        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Object died.");
        // Add logic for what happens when the object dies
        // For example: Destroy(gameObject);
        Destroy(gameObject);
    }
}
