using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    [SerializeField] float baseLives = 3f;
    float lives;
    Text livesText;


    void Start()
    {
        lives = baseLives - PlayerPrefsControler.GetDifficulty();
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
            FindObjectOfType<LevelManager>().HandleLoseCondition();
        }


    }

    public float GetLives()
    {
        return lives;
    }

}
