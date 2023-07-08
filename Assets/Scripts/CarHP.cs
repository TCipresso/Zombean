using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarHP : MonoBehaviour
{
    public int health;
    public GameObject explosionPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Debug.Log("car go boom");
            GameObject explosionInstance = Instantiate(explosionPrefab, transform.position, Quaternion.identity); // separate enemy script for each one.
            Destroy(gameObject);

        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
