using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseEffect : MonoBehaviour
{
    public float blinkInterval = 0.5f; 
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

        timer = blinkInterval; 
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