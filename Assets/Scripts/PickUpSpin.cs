using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpin : MonoBehaviour
{
    public float spinSpeed = 100;

    private void Update()
    {
        
        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
    }
}
