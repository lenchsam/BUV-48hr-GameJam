using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RecourceManager : MonoBehaviour
{
    private int numPlasticThisTurn = 0;
    [SerializeField] private TMP_Text plasticText;

    // Update is called once per frame
    void Start()
    {
        numPlasticThisTurn = 0;
        UpdatePlasticText();
    }
    private void UpdatePlasticText()
    {
        plasticText.text = numPlasticThisTurn.ToString();
    }
    public void CollectedPlastic()
    {
        numPlasticThisTurn++;
        UpdatePlasticText();
    }
    public void clearPlastic()
    {
        numPlasticThisTurn = 0;
    }
    public int GetPlastic()
    {
        return numPlasticThisTurn;
    }
}
