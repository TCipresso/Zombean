using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour
{
    public GameObject Build1;
    public GameObject Build2;
    public GameObject Build3;

    private List<GameObject> buildings = new List<GameObject>();

    private void Start()
    {
        // Add all the building GameObjects to the list.
        buildings.Add(Build1);
        buildings.Add(Build2);
        buildings.Add(Build3);

        // Initially set all the buildings inactive.
        foreach (GameObject building in buildings)
        {
            building.SetActive(false);
        }
    }

    public void Construct()
    {
        // First, deactivate all buildings to ensure only one is active at a time.
        foreach (GameObject building in buildings)
        {
            building.SetActive(false);
        }

        // Randomly pick and activate one of the buildings.
        int randomIndex = Random.Range(0, buildings.Count);
        buildings[randomIndex].SetActive(true);
    }
}
