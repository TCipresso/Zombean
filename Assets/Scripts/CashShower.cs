    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashShower : MonoBehaviour
{

    public static CashShower Instance; // Singleton instance

    public GameObject CashPrefab;
    public float mapXMin;
    public float mapXMax;
    public float mapZMin;
    public float mapZMax;
    public float heightAboveMap;
    private bool missileLaunched = false; // New variable to track whether the cash drop has been launched

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keeps the object alive between scenes
        }
        else
        {
            Destroy(gameObject); // Destroys extra instances if more than one exists
        }
    }

    public void Spawn()
    {
        if (missileLaunched) 
        {
            return; 
        }
        missileLaunched = true;

        int numCashToSpawn = Random.Range(5, 10); 
        StartCoroutine(SpawnWithDelay(numCashToSpawn));
    }

    IEnumerator SpawnWithDelay(int numCashToSpawn)
    {
        for (int i = 0; i < numCashToSpawn; i++)
        {
            float x = Random.Range(mapXMin, mapXMax);
            float z = Random.Range(mapZMin, mapZMax);
            float y = GetHighestPoint(x, z) + heightAboveMap;

            Vector3 spawnPosition = new Vector3(x, y, z);

            Instantiate(CashPrefab, spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(1.5f); 
        }

        missileLaunched = false;
        Destroy(gameObject, 30f); 
    }

    private float GetHighestPoint(float x, float z)
    {
        

        RaycastHit hit;
        if (Physics.Raycast(new Vector3(x, 1000, z), -Vector3.up, out hit))
        {
            return hit.point.y;
        }
        else
        {
            return 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            Spawn();

            Debug.Log("Cash shower activated");
            MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
            if (meshRenderer != null)
            {
                meshRenderer.enabled = false;
            }
            
        }
    }
}
