using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float explosionRadius;
    public int damage;
    public GameObject explosionPrefab;

    private bool exploded = false;

    void Start()
    {
        Physics.IgnoreLayerCollision(6, 9, true);
        Physics.IgnoreLayerCollision(9, 9, true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!exploded)
        {
            Explode();
            exploded = true;
        }
    }

    private void Explode()
    {
        
        GameObject explosionInstance = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(explosionInstance, 1f);
        Destroy(gameObject);
    }
}
