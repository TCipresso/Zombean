using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningSCript : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void ShowWarning()
    {
        meshRenderer.enabled = true;
        // Start a coroutine or another method to make the warning blink.
    }

    public void HideWarning()
    {
        meshRenderer.enabled = false;
        // Stop the blinking effect if you implemented it using a coroutine.
    }
}
