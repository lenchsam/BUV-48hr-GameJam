using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    [SerializeField] Vehicle vehicleScript;
    [SerializeField] Health playerHealth;
    [SerializeField] NumPlasticScriptablObject SO_Plastic;
    [SerializeField] UpgradeScriptableObject SO_Upgrades;

    public void BetterHandling()
    {
        if(vehicleScript.steering < 160)
        {
            vehicleScript.steering += 5;
            SO_Upgrades.numOfHandling++;
        }
    }
    void moreHealth()
    {
        playerHealth.health += 5;
        playerHealth.UpdateHealthText();
    }
    void protection()
    {

    }
    void biggerCollectionArea()
    {
        SO_Upgrades.numOfBiggerCollectableArea++;
    }
    void CheaperUpgrades()
    {
        SO_Upgrades.numOfCheaperUpgrades++;
    }
    void Buy(int Price)
    {
        if (SO_Plastic.plasticNumber >= Price)
        {
            SO_Plastic.plasticNumber -= Price;
        }
    }
}
