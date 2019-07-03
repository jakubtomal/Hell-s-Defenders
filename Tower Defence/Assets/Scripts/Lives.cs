using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    [SerializeField] int lives = 5;
    Text livesText;


    void Start()
    {
        livesText = GetComponent<Text>();
        UpdateDesplay();
    }

    private void UpdateDesplay()
    {
        livesText.text = lives.ToString();
    }

    public void TakeLives(int amount)
    {


        lives -= amount;
        UpdateDesplay();
        if(lives <= 0)
        {
            FindObjectOfType<SceneLoader>().LoadStartSceene();
        }


    }

}
