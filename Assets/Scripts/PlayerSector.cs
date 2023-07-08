using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSector : MonoBehaviour
{
    public string currentSector;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("NorthSector"))
        {
            currentSector = "North";
            Debug.Log("North");
        }
        else if (other.gameObject.CompareTag("SouthSector"))
        {
            currentSector = "South";
            Debug.Log("South");
        }
    }
}
