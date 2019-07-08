using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    int currentSceneIndex;

    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex == 0)
        {
            StartCoroutine(LoadSceeneWithDelay(2f, 1));
        }
    }


    public void LoadSceene(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }

    public void LoadSceene(string Scenename)
    {
        SceneManager.LoadScene(Scenename);
    }

    public void LoadStartSceene()
    {
        StartCoroutine(LoadSceeneWithDelay(0f, 1));
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void RestertScene()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Start Screen");
    }

    public void LoadOptionsScene()
    {
        SceneManager.LoadScene("Option Screen"); 
    }

    public void QuitGame()
    {
        Application.Quit();
    }

 public IEnumerator LoadSceeneWithDelay(float delay , int sceneIndex)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneIndex);
    }
}
