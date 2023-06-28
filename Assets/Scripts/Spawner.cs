using System.Collections;
using UnityEngine;


/*
 * Spawner is simple script that will intantiate a prefab at a random location in a range of the X axis.
 * due to the y axis alwasy changing by falling only need to randomly select x axis.
 */
public class Spawner : MonoBehaviour
{
    public GameObject blockPrefab; //Block that will spawn.
    public float spawnRate = 1f; //rate at which blocks will spawn.
    public float Min; // the minimum x position the blocks will spawn.
    public float Max; // the maximum x position the blocks will spawn.

    void Start()
    {
        StartCoroutine(SpawnBlocks());
    }

    IEnumerator SpawnBlocks()
    {
        while (true)
        {
            
            float x = Random.Range(Min, Max); //handles RNG.

            // create a new position vector with the random x position and the spawner's y position
            Vector3 spawnPosition = new Vector3(x, transform.position.y, transform.position.z);

            Instantiate(blockPrefab, spawnPosition, Quaternion.identity); // instantiate a new block at the position of the Random numbers.

            yield return new WaitForSeconds(spawnRate); // Spawn based on the spawnRate.
        }
    }
}
