using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class CollectItem : MonoBehaviour
{
    private RecourceManager RM;
    [SerializeField] private PlacePlastic randomPlacer;

    void Start()
    {
        RM = GameObject.Find("----RecourceManager----").GetComponent<RecourceManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Plastic")
        {
            //Debug.Log("Collected Item");
            RM.CollectedPlastic();
            randomPlacer.RemoveObject(other.gameObject);
            Destroy(other.gameObject);
        }
    }
}
