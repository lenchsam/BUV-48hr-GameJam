using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class RecourceManager : MonoBehaviour
{
    private int numPlastic = 0;
    [SerializeField] private TMP_Text plasticText;

    // Update is called once per frame
    void Start()
    {
        UpdatePlasticText();
    }
    private void UpdatePlasticText()
    {
        plasticText.text = numPlastic.ToString();
    }
    public void CollectedPlastic()
    {
        numPlastic++;
        UpdatePlasticText();
    }
}
