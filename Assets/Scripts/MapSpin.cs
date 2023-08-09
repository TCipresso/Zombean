using System.Collections;
using UnityEngine;

public class MapSpin : MonoBehaviour
{
    public float maxSpinSpeed = 100;
    private bool isSpinning;
    private float currentSpinSpeed;

    private void Update()
    {
        if (isSpinning)
        {
            transform.Rotate(Vector3.up, currentSpinSpeed * Time.deltaTime);
        }
    }

    public void StartSpinning(float duration)
    {
        isSpinning = true;
        StartCoroutine(SpinAndSlowDown(duration));
    }

    private IEnumerator SpinAndSlowDown(float duration)
    {
        float elapsed = 0;

        while (elapsed < duration)
        {
            float normalizedTime = elapsed / duration;

            // Using a squared curve for deceleration
            currentSpinSpeed = maxSpinSpeed * (1 - normalizedTime * normalizedTime);

            elapsed += Time.deltaTime;
            yield return null;
        }

        currentSpinSpeed = 0;
        isSpinning = false;
    }
}
