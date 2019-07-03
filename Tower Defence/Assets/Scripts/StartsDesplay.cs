using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartsDesplay : MonoBehaviour
{

    [SerializeField] int stars = 100;
    Text starsText;

    void Start()
    {
        starsText = GetComponent<Text>();
        UpdateDesplay();
    }

    private void UpdateDesplay()
    {
        starsText.text = stars.ToString();
    }

    public void AddStars(int amount)
    {
        stars += amount;
        UpdateDesplay();
    }

    public void SpendStars(int amount)
    {

        if(stars >= amount)
        {
            stars -= amount;
            UpdateDesplay();
        }
        
    }

    public bool HaveEnoughStars(int amount)
    {
        return stars >= amount;
    }

}
