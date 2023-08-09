using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieNoise : MonoBehaviour
{
    public AudioClip[] zombieNoises;
    public float minTimeBetweenNoises = 3f;
    public float maxTimeBetweenNoises = 10f;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlayRandomNoise());
    }

    IEnumerator PlayRandomNoise()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minTimeBetweenNoises, maxTimeBetweenNoises));
            audioSource.PlayOneShot(zombieNoises[Random.Range(0, zombieNoises.Length)]);
        }
    }
}