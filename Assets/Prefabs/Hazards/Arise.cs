using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arise : MonoBehaviour
{
    public float riseHeight = 5f;
    public float duration = 2f;

    void OnEnable()
    {
        StartCoroutine(Rise());
    }

    IEnumerator Rise()
    {
        Vector3 startPos = transform.position;
        Vector3 endPos = startPos + new Vector3(0, riseHeight, 0);
        float timeElapsed = 0;

        while (timeElapsed < duration)
        {
            transform.position = Vector3.Lerp(startPos, endPos, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = endPos;
    }
}