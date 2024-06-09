using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public float health = 100f; // Initial health value
    [SerializeField] TMPro.TMP_Text HealthText;
    [SerializeField] RecourceManager RM;
    [SerializeField] string sceneToLoad;
    private void Start()
    {
        UpdateHealthText();
    }
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
        //Debug.Log("Health: " + health);
        UpdateHealthText();
        if (health <= 0f)
        {
            Die();
        }
    }
    public void UpdateHealthText()
    {
        HealthText.text = health.ToString();
    }
    void Die()
    {

        //Debug.Log("Object died.");
        // Add logic for what happens when the object dies
        RM.clearPlastic();

        SceneManager.LoadScene(sceneToLoad);
    }
}
