using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialiseScriptableObjects : MonoBehaviour
{
    [SerializeField] NumPlasticScriptablObject TotalPlastic;
    [SerializeField] UpgradeScriptableObject SO_Upgrade;
    private void Start()
    {
        TotalPlastic.plasticNumber = 0;
        SO_Upgrade.numOfHandling = 0;
        SO_Upgrade.numOfBiggerCollectableArea = 0;
        SO_Upgrade.numOfCheaperUpgrades = 0;
    }
}
