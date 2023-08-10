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
        
    }

    public void HideWarning()
    {
        meshRenderer.enabled = false;
       
    }
}
