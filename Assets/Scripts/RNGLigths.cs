using UnityEngine;

public class RNGLigths : MonoBehaviour
{
    private Material material;
    public float changeInterval = 1f;

    void Start()
    {
        material = GetComponent<Renderer>().material;
        InvokeRepeating(nameof(ChangeColor), changeInterval, changeInterval);
    }

    void ChangeColor()
    {
        Color newColor = new Color(Random.value, Random.value, Random.value);
        material.SetColor("_EmissionColor", newColor);
    }
}
