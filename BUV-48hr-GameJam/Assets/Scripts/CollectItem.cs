using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : MonoBehaviour
{
    private RecourceManager RM;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Plastic")
        {
            Debug.Log("ASDFONJASJCBBJSDD");
            RM.CollectedPlastic();
            Destroy(other.gameObject);
        }
    }

    void Start()
    {
        RM = GameObject.Find("----RecourceManager----").GetComponent<RecourceManager>();
    }
}
