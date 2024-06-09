using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNewSceneAfter : MonoBehaviour
{
    [SerializeField] string sceneToLoad;

    [SerializeField] private float delayInSeconds = 6f;

    void Start()
    {
        // Start the coroutine to change scene after a delay
        StartCoroutine(ChangeSceneWithDelay());
    }

    IEnumerator ChangeSceneWithDelay()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delayInSeconds);

        // Load the new scene
        SceneManager.LoadScene(sceneToLoad);
    }
}
