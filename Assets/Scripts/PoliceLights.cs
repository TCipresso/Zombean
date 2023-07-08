using System.Collections;
using UnityEngine;

public class PoliceLights : MonoBehaviour
{
    private Light lightSource;
    public float changeSpeed = 0.5f;

    void Start()
    {
        lightSource = GetComponent<Light>();
        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        while (true)
        {
            lightSource.color = Color.red;
            yield return new WaitForSeconds(changeSpeed);
            lightSource.color = Color.blue;
            yield return new WaitForSeconds(changeSpeed);
        }
    }
}
