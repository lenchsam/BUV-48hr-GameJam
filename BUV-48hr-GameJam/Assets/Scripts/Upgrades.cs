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
    [SerializeField] int maxHandling = 16;
    [SerializeField] int maxHealth;
    [SerializeField] int maxprotection;
    [SerializeField] int maxCollection;
    [SerializeField] int maxCheap;
    [SerializeField] TMP_Text errorText;
    [Header("prices")]
    [SerializeField] private int handlingPrice;
    [SerializeField] private int healthPrice;
    [SerializeField] private int protectionPrice;
    [SerializeField] private int collectionPrice;
    [SerializeField] private int CheaperUpgradesPrice;

    public void BetterHandling()
    {
        if (SO_Upgrades.numOfHandling + 1 < maxHandling)
        {
            if (Buy(handlingPrice))
            {
                SO_Upgrades.numOfHandling++;
                HandlingNum.text = SO_Upgrades.numOfHandling.ToString();
                //take money
            }
            else
            {
                showText("NotEnoughMoney");
            }
        }
        else
        {
            showText("Max Handlings");
        }
    }
    public void moreHealth()
    {
        if (SO_Upgrades.numOfHealthUpgrades + 1 < maxHealth)
        {
            if (Buy(healthPrice))
            {
                SO_Upgrades.numOfHealthUpgrades++;
                HealthNum.text = SO_Upgrades.numOfHealthUpgrades.ToString();
            }
            else
            {
                showText("NotEnoughMoney");
            }
        }
        else
        {
            showText("Max Health");
        }
    }
    public void protection()
    {
        if (SO_Upgrades.numOfProtection + 1 < maxprotection)
        {
            if (Buy(protectionPrice))
            {
                SO_Upgrades.numOfProtection++;
                protectionNum.text = SO_Upgrades.numOfProtection.ToString();
            }
            else
            {
                showText("NotEnoughMoney");
            }
        }
        else
        {
            showText("Max Protection");
        }
    }
    public void biggerCollectionArea()
    {
        if (SO_Upgrades.numOfBiggerCollectableArea + 1 < maxCollection)
        {
            if (Buy(collectionPrice))
            {
                SO_Upgrades.numOfBiggerCollectableArea++;
                collectionAreaNum.text = SO_Upgrades.numOfBiggerCollectableArea.ToString();
                //take money
            }
            else
            {
                showText("NotEnoughMoney");
            }
        }
        else
        {
            showText("Max Collection Area");
        }
    }
    public void CheaperUpgrades()
    {
        if (SO_Upgrades.numOfCheaperUpgrades + 1 < maxCheap)
        {
            if (Buy(CheaperUpgradesPrice))
            {
                SO_Upgrades.numOfCheaperUpgrades++;
                cheaperUpgradesNum.text = SO_Upgrades.numOfCheaperUpgrades.ToString();
            }
            else
            {
                showText("NotEnoughMoney");
            }
        }
        else
        {
            showText("Max Collection Area");
        }
    }
    private bool Buy(int Price)
    {
        if (SO_Plastic.plasticNumber >= Price)
        {
            SO_Plastic.plasticNumber -= Price;
            return true;
        }
        else
        {
            return false;
        }
    }
    void showText(string text)
    {
        errorText.gameObject.SetActive(true);
        errorText.text = text;
    }
}
