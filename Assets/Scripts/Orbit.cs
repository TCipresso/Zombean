using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{

    public Transform playerTransform;
    public float orbitSpeed;

    
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        transform.RotateAround(playerTransform.position, Vector3.up, orbitSpeed * Time.deltaTime);

    }

}
