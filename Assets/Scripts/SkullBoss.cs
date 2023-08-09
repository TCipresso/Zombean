using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullBoss : MonoBehaviour
{
    public GameObject prefab; // Reference to the prefab
    public Vector3 spawnPosition;
    public float BossDuration;

    private GameObject SpawnedBoss;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnSkull()
    {
        if (SpawnedBoss != null)
        {
            return;
        }
        SpawnedBoss = Instantiate(prefab, spawnPosition, Quaternion.identity);
       // Destroy(SpawnedBoss, HazardDuration);
    }
}
