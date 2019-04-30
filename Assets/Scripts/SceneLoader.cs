using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadPlayscreen()    
    {
        SceneManager.LoadScene("Playscreen");
    }

    public void LoadMainscreen()
    {
        SceneManager.LoadScene("Mainscreen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
