using System.Collections;
using UnityEngine;


/*
 * BarrierSpawner spawns the barriers the player cannot pass through.
 * constantly spawns at a rate and is attactedh to the camera holder to always follow the player as they fall.
 */
public class BarrierSpawner : MonoBehaviour
{
    public GameObject barrierPrefab; //prefab for the barriers.
    public float spawnRate = 1f; //how fast they spawn.

    void Start()
    {
        StartCoroutine(SpawnBlocks());

    }

    IEnumerator SpawnBlocks()
    {
        while (true)
        {
            
            Instantiate(barrierPrefab, transform.position, Quaternion.identity);//instantiate block.

            yield return new WaitForSeconds(spawnRate); //makes sure they spawn at a certain time or rythim indefinitely.
        }
    }
}
