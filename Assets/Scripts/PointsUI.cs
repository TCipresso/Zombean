using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsUI : MonoBehaviour
{
    public MoneyLogic pointsManager;
    private Text pointsText;

    private void Start()
    {
        pointsText = GetComponent<Text>();
    }

    private void Update()
    {
        UpdatePointsText();
    }

    private void UpdatePointsText()
    {
        //Debug.Log("Updating points text");
        pointsText.text = "Points: " + pointsManager.GetPoints();
    }
}
