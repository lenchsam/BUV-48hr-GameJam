using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    [SerializeField] Vehicle vehicleScript;
    [SerializeField] Health playerHealth;
    [SerializeField] NumPlasticScriptablObject SO_Plastic;

    public void BetterHandling()
    {
        if(vehicleScript.steering < 160)
            vehicleScript.steering += 5;
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
        
    }
    void CheaperUpgrades()
    {

    }
    void Buy(int Price)
    {
        if (SO_Plastic.plasticNumber >= Price)
        {
            SO_Plastic.plasticNumber -= Price;
        }
    }
}
