using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class RecourcesManager : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] private TMP_Text woodText;
    [SerializeField] private TMP_Text moneyText;

    [HideInInspector] public int Money = 0;
    [HideInInspector] public int NumWood = 0;

    private void Start()
    {
        UpdateWood(0);
        //UpdateMoney(0);
    }
    public void UpdateMoney(int moneyToAdd)
    {
        Money += moneyToAdd;
        moneyText.text = Money.ToString();
    }
    public void UpdateWood(int WoodToAdd)
    {
        NumWood += WoodToAdd;
        woodText.text = NumWood.ToString();
    }
}
