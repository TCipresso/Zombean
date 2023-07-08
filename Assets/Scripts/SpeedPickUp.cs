using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPickUp : MonoBehaviour
{

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.StartSpeedBoost(20f, 7.5f);
                Debug.Log("Speed Boost started");
                Destroy(gameObject);
            }
        }
    }
}


