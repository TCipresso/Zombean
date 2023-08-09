using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseEffect : MonoBehaviour
{
    public float blinkInterval = 0.5f; // The time interval between blinks
    private MeshRenderer meshRenderer;
    private bool isRendererOn = true;
    private float timer;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        if (meshRenderer == null)
        {
            Debug.LogError("No MeshRenderer found. Blink effect won't work.");
            return;
        }

        timer = blinkInterval; // Start with the interval so it blinks immediately upon starting
    }

    void Update()
    {
        if (!meshRenderer) return;

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            isRendererOn = !isRendererOn;
            meshRenderer.enabled = isRendererOn;
            timer = blinkInterval;
        }
    }
}