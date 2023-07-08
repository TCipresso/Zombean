using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NUKE : MonoBehaviour
{
    public GameObject missilePrefab;
    public float mapXMin;
    public float mapXMax;
    public float mapZMin;
    public float mapZMax;
    public float heightAboveMap;
    private bool missileLaunched = false; 

    public void Spawn()
    {
        if (missileLaunched) 
        {
            return; 
        }

        float x = 0;
        float z = 0;
        float y = GetHighestPoint(x, z) + heightAboveMap;

        Vector3 spawnPosition = new Vector3(x, y, z);

        Instantiate(missilePrefab, spawnPosition, Quaternion.identity);

        missileLaunched = true; 
    }

    private float GetHighestPoint(float x, float z)
    {
        
        
        RaycastHit hit;
        if (Physics.Raycast(new Vector3(x, 1000, z), -Vector3.up, out hit))
        {
            return hit.point.y;
        }
        else
        {
            return 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            Spawn();

            Debug.Log("Nuke spawned");
            Destroy(gameObject);
        }
        /*else if (other.gameObject.tag == "NorthSector")
        {
            //rb.isKinematic = false;
            //Physics.IgnoreLayerCollision(6, 9, true);
            //do nothing
        }
        else if (other.gameObject.tag == "SouthSector")
        {
            //rb.isKinematic = false;
            //Physics.IgnoreLayerCollision(6, 9, true);
            //do nothing
        }*/

    }
}

