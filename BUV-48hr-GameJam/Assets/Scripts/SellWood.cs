using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellWood : MonoBehaviour
{
    private RecourcesManager RM;
    [SerializeField] private Slider SellSlider;
    void Awake()
    {
        RM = GameObject.Find("----RecourcesManager----").GetComponent<RecourcesManager>();
        Debug.Log(SellSlider.maxValue);
    }
    void OnEnable()
    {
        SellSlider.maxValue = RM.NumWood;
        SellSlider.value = 0;  //The slider starts at 0
    }
    public void F_SellWood()
    {
        if (RM.NumWood > SellSlider.value) //enough wood to sell?
        {
            Debug.Log("running" + SellSlider.value);
            RM.UpdateWood(-(int)SellSlider.value);
            gameObject.transform.parent.gameObject.SetActive(false);
        }
    }
}
