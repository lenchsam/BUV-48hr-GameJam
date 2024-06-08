using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Upgrades : MonoBehaviour
{
    [SerializeField] NumPlasticScriptablObject SO_Plastic;
    [SerializeField] UpgradeScriptableObject SO_Upgrades;
    [SerializeField] TMP_Text HandlingNum;
    [SerializeField] TMP_Text HealthNum;
    [SerializeField] TMP_Text protectionNum;
    [SerializeField] TMP_Text collectionAreaNum;
    [SerializeField] TMP_Text cheaperUpgradesNum;

    public void BetterHandling()
    {
        SO_Upgrades.numOfHandling++;
        HandlingNum.text = SO_Upgrades.numOfHandling.ToString();
    }
    public void moreHealth()
    {
        SO_Upgrades.numOfHealthUpgrades++;
        HealthNum.text = SO_Upgrades.numOfHealthUpgrades.ToString();
    }
    public void protection()
    {
        SO_Upgrades.numOfProtection++;
        protectionNum.text = SO_Upgrades.numOfProtection.ToString();
    }
    public void biggerCollectionArea()
    {
        SO_Upgrades.numOfBiggerCollectableArea++;
        collectionAreaNum.text = SO_Upgrades.numOfBiggerCollectableArea.ToString();
    }
    public void CheaperUpgrades()
    {
        SO_Upgrades.numOfCheaperUpgrades++;
        cheaperUpgradesNum.text = SO_Upgrades.numOfCheaperUpgrades.ToString();
    }
     void Buy(int Price)
    {
        if (SO_Plastic.plasticNumber >= Price)
        {
            SO_Plastic.plasticNumber -= Price;
        }
    }
}
