using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeRot : MonoBehaviour
{
    private bool isRotted = false;
    [SerializeField] private float rotChance = 0.01f; // Chance of rotting per second

    // Start is called before the first frame update
    void Start()
    {
        // Start the rotting process
        StartCoroutine(CheckForRot());
    }

    // Coroutine to randomly rot the tree over time
    IEnumerator CheckForRot()
    {
        while (!isRotted)
        {
            // Check if the tree should rot
            if (Random.value < rotChance)
            {
                isRotted = true;
                Debug.Log(gameObject.name + " has rotted.");
            }
            // Wait for 1 second before checking again
            yield return new WaitForSeconds(1f);

        }
    }
}
