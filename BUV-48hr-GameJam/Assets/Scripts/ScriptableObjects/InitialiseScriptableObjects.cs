using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialiseScriptableObjects : MonoBehaviour
{
    [SerializeField] private NumPlasticScriptablObject TotalPlastic;
    private void Start()
    {
        TotalPlastic.plasticNumber = 0;
    }
}
