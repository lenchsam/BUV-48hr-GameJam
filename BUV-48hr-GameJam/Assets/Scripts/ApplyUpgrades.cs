using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyUpgrades : MonoBehaviour
{
    [SerializeField] Vehicle vehicleScript;
    [SerializeField] Health playerHealth;
    [SerializeField] UpgradeScriptableObject SO_Upgrades;
    // Start is called before the first frame update
    void Start()
    {
        if (vehicleScript.steering < 160)
        {
            vehicleScript.steering += 5 * SO_Upgrades.numOfHandling;
        }

        playerHealth.health += 5 * SO_Upgrades.numOfHealthUpgrades;
        playerHealth.UpdateHealthText();

    }
}
