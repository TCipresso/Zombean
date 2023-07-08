using System.Collections;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    private Light lightSource;
    public float minIntensity = 0.25f;
    public float maxIntensity = 0.5f;
    public float flickerSpeed = 0.1f;

    void Start()
    {
        lightSource = GetComponent<Light>();
        StartCoroutine(Flicker());
    }

    IEnumerator Flicker()
    {
        while (true)
        {
            lightSource.intensity = Random.Range(minIntensity, maxIntensity);
            yield return new WaitForSeconds(flickerSpeed);
        }
    }
}
