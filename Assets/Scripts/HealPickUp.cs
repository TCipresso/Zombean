using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPickUp : MonoBehaviour
{
    public PlayerStats Heal;
    // Start is called before the first frame update
    void Start()
    {
        Heal = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            Heal.PlayerHeal();

            Debug.Log("Player Healed");
            Destroy(gameObject);
        }

    }
}
