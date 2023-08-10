using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [System.Serializable]
    public class WeightedZombiePrefab
    {
        public GameObject prefab;
        public int weight = 1;
    }

    public GameObject player;
    private PlayerSector playerSector;

    [SerializeField] private float spawnRate;
    [SerializeField] private float initialSpawnRate;
    [SerializeField] private float difficultyMultiplier = 1f;
    [SerializeField] private float difficultyIncreaseInterval = 10f;
    [SerializeField] private WeightedZombiePrefab[] ZombeanPrefabs;
    [SerializeField] private bool SpawnCap = true;
    [SerializeField] public bool infiniteSpawn = false;
    [SerializeField] private int SpawnCount;
    public int spawnLimit;
    [SerializeField] private int initialSpawnLimit;
    int spawned;

    private Vector3 northSpawnRangeStart = new Vector3(-25f, 1.6f, 0f);
    private Vector3 northSpawnRangeEnd = new Vector3(25f, 1.6f, 25f);
    private Vector3 southSpawnRangeStart = new Vector3(-25f, 1.6f, -25f);
    private Vector3 southSpawnRangeEnd = new Vector3(25f, 1.6f, 0f);

    private void Start()
    {
        playerSector = player.GetComponent<PlayerSector>();
        StartCoroutine(spawner());
        StartCoroutine(IncreaseDifficulty());
    }

    private IEnumerator spawner()
    {
        int totalWeight = 0;
        foreach (var prefab in ZombeanPrefabs)
            totalWeight += prefab.weight;

        while (infiniteSpawn || (SpawnCap && spawned < spawnLimit))
        {
            if (MenuLogic.isPaused) 
            {
                yield return null;
                continue; 
            }

            WaitForSecondsRealtime wait = new WaitForSecondsRealtime(spawnRate / difficultyMultiplier);
            yield return wait;

            int randWeight = Random.Range(0, totalWeight);
            GameObject enemyToSpawn = null;


            foreach (var prefab in ZombeanPrefabs)
            {
                if (randWeight < prefab.weight)
                {
                    enemyToSpawn = prefab.prefab;
                    break;
                }

                randWeight -= prefab.weight;
            }


            Vector3 spawnPosition;
            if (playerSector.currentSector == "South")
            {
                spawnPosition = new Vector3(
                    Random.Range(northSpawnRangeStart.x, northSpawnRangeEnd.x),
                    1.6f,
                    Random.Range(northSpawnRangeStart.z, northSpawnRangeEnd.z)
                );
            }
            else
            {
                spawnPosition = new Vector3(
                    Random.Range(southSpawnRangeStart.x, southSpawnRangeEnd.x),
                    1.6f,
                    Random.Range(southSpawnRangeStart.z, southSpawnRangeEnd.z)
                );
            }

            Instantiate(enemyToSpawn, spawnPosition, Quaternion.identity);
            spawned++;
        }
    }

    private IEnumerator IncreaseDifficulty()
    {
        while (true)
        {
            if (MenuLogic.isPaused) 
            {
                yield return null; 
                continue; 
            }

            yield return new WaitForSeconds(difficultyIncreaseInterval);
            difficultyMultiplier += 0.1f; // Increase difficulty by 10% = 0.1
            spawnRate = initialSpawnRate / difficultyMultiplier;
            spawnLimit = (int)(initialSpawnLimit * difficultyMultiplier);
            Debug.Log("increased Difficulty");
        }
    }
}
