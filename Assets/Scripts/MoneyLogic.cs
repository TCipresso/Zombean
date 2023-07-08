using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyLogic : MonoBehaviour
{
    private int points = 0;

    public void AddPoints(int pointsToAdd)
    {
        points += pointsToAdd;
        Debug.Log("Points added: " + pointsToAdd);
    }

    public int GetPoints()
    {
        return points;
    }
}
