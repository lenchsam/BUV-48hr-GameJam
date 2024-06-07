using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantTree : MonoBehaviour
{
    public GameObject prefab;  // The prefab to be placed
    public LayerMask placementLayerMask; // Layer mask to determine valid placement surfaces

    // Update is called once per frame
    void Update()
    {
        // Check for mouse input
        if (Input.GetMouseButtonDown(0))
        {
            // Create a ray from the camera to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits any collider on the specified layer
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, placementLayerMask))
            {
                Debug.Log("HIT");
                // Instantiate the prefab at the hit point and with the default rotation
                Instantiate(prefab, hit.point, Quaternion.identity);
            }
        }
    }
}
