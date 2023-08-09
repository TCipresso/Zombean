using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamDelay : MonoBehaviour
{
    public float delayInSeconds;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(AfterDelay());
    }

    public IEnumerator AfterDelay()
    {
        yield return new WaitForSeconds(delayInSeconds);
        audioSource.Play();
    }
}
