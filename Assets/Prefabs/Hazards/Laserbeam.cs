using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laserbeam : MonoBehaviour
{
    public GameObject laserPrefab;
    public Transform player;
    public float distanceFromPlayer = 5f;
    public float delayBetweenLasers = 1f;
    private bool isFiring = false;

    // Define the map boundaries
    public float minX = -50f;
    public float maxX = 50f;
    public float minZ = -50f;
    public float maxZ = 50f;

    // Random rotation deviation range
    public float randomDeviation = 15f; // max deviation in degrees

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void FireLasers()
    {
        if (!isFiring)
        {
            StartCoroutine(FireLasersCoroutine());
        }
    }

    private IEnumerator FireLasersCoroutine()
    {
        isFiring = true;

        for (int i = 0; i < 5; i++)
        {
            Vector3 randomOffset = Random.insideUnitSphere * distanceFromPlayer;
            randomOffset.y = 0;
            Vector3 spawnPosition = player.position + randomOffset;

            // Clamp the spawn position to within map boundaries
            spawnPosition.x = Mathf.Clamp(spawnPosition.x, minX, maxX);
            spawnPosition.z = Mathf.Clamp(spawnPosition.z, minZ, maxZ);

            Vector3 directionToPlayer = (player.position - spawnPosition).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);

            // Add a slight random deviation to the rotation
            Quaternion randomRotation = Quaternion.Euler(0, Random.Range(-randomDeviation, randomDeviation), 0);
            targetRotation *= randomRotation;

            Instantiate(laserPrefab, spawnPosition, targetRotation);

            yield return new WaitForSeconds(delayBetweenLasers);
        }

        isFiring = false;
    }
}

