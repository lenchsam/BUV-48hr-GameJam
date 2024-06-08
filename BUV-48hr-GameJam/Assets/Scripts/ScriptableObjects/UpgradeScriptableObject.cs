using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NumPlastic", menuName = "ScriptableObjects/NumPlastic")]

public class UpgradeScriptableObject : ScriptableObject
{
    public int numOfHandling;
    public int numOfBiggerCollectableArea;
    public int numOfCheaperUpgrades;
}
