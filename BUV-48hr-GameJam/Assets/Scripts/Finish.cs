using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] NumPlasticScriptablObject totalPlastic;
    [SerializeField] RecourceManager RM;

    private void OnTriggerEnter(Collider other)
    {
        totalPlastic.plasticNumber += RM.GetPlastic();
    }
}
