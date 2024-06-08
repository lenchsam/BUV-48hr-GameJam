using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void QuitGame()
    {
        // Quits the game if the application is running
        // This won't have an effect in the editor
        Application.Quit();

#if UNITY_EDITOR
        // If we're running in the editor, stop playing the scene
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
