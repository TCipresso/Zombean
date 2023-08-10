using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealZone : MonoBehaviour
{
    public int healingAmount = 2; 
    public float healingInterval = 1.0f; 

    private PlayerStats playerStats;
    private Coroutine healingCoroutine; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerStats = other.GetComponent<PlayerStats>(); 

            if (playerStats != null && healingCoroutine == null)
            {
                
                healingCoroutine = StartCoroutine(HealPlayer());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<PlayerStats>() != null && healingCoroutine != null)
            {
                StopCoroutine(healingCoroutine);
                healingCoroutine = null; 
            }
        }
    }

    private IEnumerator HealPlayer()
    {
        while (true) 
        {
            yield return new WaitForSeconds(healingInterval); 
            playerStats.HealZone(healingAmount); 
        }
    }
}
