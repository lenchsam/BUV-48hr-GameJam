using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNewScene : MonoBehaviour
{
    [SerializeField] string sceneName;
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("entered");
        if (other.gameObject.tag == "Player")
        {
        // Load the specified scene
        SceneManager.LoadScene(sceneName);
        }
    }
}
