using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    public GameObject prefab; 
    public Vector3 spawnPosition;
    public float HazardDuration;

    private GameObject SpawnedHazard;
    
    void Start()
    {
        //SpawnHazard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnHazard()
    {
        if (SpawnedHazard != null)
        {
            return;
        }
        SpawnedHazard = Instantiate(prefab, spawnPosition, Quaternion.identity);
       Destroy(SpawnedHazard, HazardDuration);
    }
}
