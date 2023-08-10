using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpin : MonoBehaviour
{
    public float maxSpinSpeed = 100;
    private bool isSpinning;
    private float currentSpinSpeed;
    private int spinDirection = 1;

    private void Update()
    {
        if (isSpinning)
        {
            transform.Rotate(Vector3.up, currentSpinSpeed * spinDirection * Time.deltaTime);
        }
    }

    public void StartSpinning(float duration)
    {
        if (Random.Range(0, 2) == 0)
        {
            spinDirection = 1;
        }
        else
        {
            spinDirection = -1;
        }

        currentSpinSpeed = Random.Range(maxSpinSpeed * 0.5f, maxSpinSpeed);

        isSpinning = true;
        StartCoroutine(SpinAndSlowDown(duration));
    }

    private IEnumerator SpinAndSlowDown(float duration)
    {
        float elapsed = 0;

        while (elapsed < duration)
        {
            float normalizedTime = elapsed / duration;
            currentSpinSpeed = maxSpinSpeed * (1 - normalizedTime * normalizedTime);

            elapsed += Time.deltaTime;
            yield return null;
        }

        currentSpinSpeed = 0;
        isSpinning = false;
    }
}
