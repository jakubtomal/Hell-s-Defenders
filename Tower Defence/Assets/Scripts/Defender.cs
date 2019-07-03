using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int startCost;

    public void AddStars(int amount)
    {
        FindObjectOfType<StartsDesplay>().AddStars(amount);
    }

    public int GetStartCost()
    {
        return startCost;
    }
}
