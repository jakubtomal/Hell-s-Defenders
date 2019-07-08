using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    [SerializeField] Color highlightColor;
    [SerializeField] Color normalColor;
    [SerializeField] Color activeColor;
    

    bool active = false;

    [SerializeField] Defender defenderPrefab;



    private void Start()
    {
        LabelButtonWithCost();
    }

    private void LabelButtonWithCost()
    {
        Text costText = GetComponentInChildren<Text>();

        if(!costText)
        {
            Debug.LogError(name + "has no cost text");
        }
        else
        {
            costText.text = defenderPrefab.GetStartCost().ToString();
        }
    }

    private void OnMouseEnter()
    {
        if(!active)
        {
            GetComponent<SpriteRenderer>().color = highlightColor;
        }
        
    }

    private void OnMouseExit()
    {
        if (!active)
        {
            GetComponent<SpriteRenderer>().color = normalColor;
        }
        
    }

    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<ShopButton>();

        foreach(ShopButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = normalColor;
            button.active = false;
        }

        GetComponent<SpriteRenderer>().color = activeColor;
        active = true;
        FindObjectOfType<DefenderSpawner>().SetActiveDefender(defenderPrefab);
    }
}
