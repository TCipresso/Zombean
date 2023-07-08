using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TheBigOne : MonoBehaviour
{
    public float speed; 
    public GameObject explosionPrefab; 

    void Update()
    {
        
        transform.position += -transform.up * speed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
       
        float yOffset = -1.4f; // 
        Instantiate(explosionPrefab, transform.position + new Vector3(0, yOffset, 0), Quaternion.identity);


        
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 5); // 5 is the radius of the blast
        foreach (var hitCollider in hitColliders)
        {
            
        }

        
        Destroy(gameObject);
    }
}
