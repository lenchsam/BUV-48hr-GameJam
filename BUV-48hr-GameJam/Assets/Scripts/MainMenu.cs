using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [Header("Assignables")]
    [SerializeField] private TMP_Text SliderText;
    public void toggleUI(GameObject thingToToggle)
    {
        if (thingToToggle.activeSelf == false)
        {
            thingToToggle.SetActive(true);
        }
        else
        {
            thingToToggle.SetActive(false);
        }
    }
    public void UpdateText(float Text)
    {
        SliderText.text = Text.ToString();
    }
}
