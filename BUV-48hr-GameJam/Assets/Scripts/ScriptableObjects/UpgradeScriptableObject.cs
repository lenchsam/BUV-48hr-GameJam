using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade", menuName = "ScriptableObjects/Upgrade")]

public class UpgradeScriptableObject : ScriptableObject
{
    public int numOfHandling;
    public int numOfBiggerCollectableArea;
    public int numOfProtection;
    public int numOfCheaperUpgrades;
    public int numOfHealthUpgrades;
}
