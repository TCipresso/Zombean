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
        
        buildings.Add(Build1);
        buildings.Add(Build2);
        buildings.Add(Build3);

       
        foreach (GameObject building in buildings)
        {
            building.SetActive(false);
        }
    }

    public void Construct()
    {
        
        foreach (GameObject building in buildings)
        {
            building.SetActive(false);
        }

        
        int randomIndex = Random.Range(0, buildings.Count);
        buildings[randomIndex].SetActive(true);
    }
}
