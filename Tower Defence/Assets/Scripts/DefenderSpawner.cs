﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defenderPrefab = null;

    private void OnMouseDown()
    {
        AttemptToPlaceAt(GetSquareClicked());
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }

    private Vector2 SnapToGrid( Vector2 rawWaoldPos)
    {
        int newX = Mathf.RoundToInt(rawWaoldPos.x);
        int newY = Mathf.RoundToInt(rawWaoldPos.y);

        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 roundedPos)
    {
        if(defenderPrefab != null)
        {
            Defender newDefender = Instantiate(defenderPrefab, roundedPos, Quaternion.identity) as Defender;
        }
        
    }

    public void SetActiveDefender(Defender currentDefender)
    {
        defenderPrefab = currentDefender;
    }

    private void AttemptToPlaceAt(Vector2 gridPos)
    {
        var starsDisplay = FindObjectOfType<StartsDesplay>();
        int defenderCost = defenderPrefab.GetStartCost();

        if(starsDisplay.HaveEnoughStars(defenderCost))
        {
            SpawnDefender(gridPos);
            starsDisplay.SpendStars(defenderCost);
        }
    }

    
}
