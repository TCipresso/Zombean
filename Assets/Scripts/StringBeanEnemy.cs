using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringBeanEnemy : MonoBehaviour
{
    public LogicScript Points;
    public int health;
    public int Money;
    public GameObject[] powerUps; // array of power up prefabs
    public float dropChance = 0.1f; // 10% drop chance
    public GameObject explosionPrefab;
    public bool IsStringBean;

    void Start()
    {
        Points = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            // Roll for power-up drop
            if (Random.value <= dropChance)
            {
                // Choose a random power-up and spawn it
                GameObject powerUpPrefab = powerUps[Random.Range(0, powerUps.Length)];
                GameObject Intance = Instantiate(powerUpPrefab, transform.position, Quaternion.identity);
                Destroy(Intance, 10f);
            }
            if (IsStringBean)
            {
                GameObject explosionInstance = Instantiate(explosionPrefab, transform.position, Quaternion.identity); // separate enemy script for each one.
               
            }

            Destroy(gameObject);
            Points.AddPoints();

        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
