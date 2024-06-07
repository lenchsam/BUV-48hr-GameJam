using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutTree : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int numWoodPerTree;
    private string TagOfHit = "Tree";

    //Variables that inspector doesnt need to see
    private RecourcesManager RM;

    void Start()
    {
        RM = GameObject.Find("----RecourcesManager----").GetComponent<RecourcesManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Create a ray from the camera to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits the collider of the cube
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == TagOfHit)
                {
                    RM.UpdateWood(numWoodPerTree);
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}
