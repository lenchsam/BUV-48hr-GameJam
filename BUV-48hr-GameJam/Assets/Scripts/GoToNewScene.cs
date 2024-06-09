using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNewScene : MonoBehaviour
{
    [SerializeField] string sceneName;
    [SerializeField] NumPlasticScriptablObject SO_Plastic;
    [SerializeField] RecourceManager RM;
    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("entered");
        if (other.gameObject.tag == "Player")
        {
            SO_Plastic.plasticNumber += RM.GetPlastic();
            RM.clearPlastic();
            // Load the specified scene
            SceneManager.LoadScene(sceneName);
        }
    }
}
