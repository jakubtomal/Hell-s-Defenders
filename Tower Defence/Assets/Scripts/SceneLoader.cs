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
            StartCoroutine(LoadSceeneWithDelay(4.0f, 1));
        }
    }


    public void LoadStartSceene()
    {
        StartCoroutine(LoadSceeneWithDelay(0f, 1));
    }

 public IEnumerator LoadSceeneWithDelay(float delay , int sceneIndex)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneIndex);
    }
}
