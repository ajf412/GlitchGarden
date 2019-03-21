using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender = null;

    private void OnMouseDown()
    {
        AttemptToPlaceDefender();
    }

    public void SetSelectedDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }

    private void AttemptToPlaceDefender()
    {
        var coinDisplay = FindObjectOfType<CoinDisplay>();
        int defenderCost = defender.GetCoinCost();

        if (coinDisplay.HaveEnoughCoins(defenderCost))
        {
            SpawnDefender(GetSquareClicked());
            coinDisplay.SpendCoins(defenderCost);
        }
        else { return; }
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);

        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 placementPos)
    {
        Defender newDefender = Instantiate(defender, placementPos, Quaternion.identity) as Defender;
    }
}
