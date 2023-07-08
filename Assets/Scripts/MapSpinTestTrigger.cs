using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpinTestTrigger : MonoBehaviour
{

    public MapSpin MapSpin;
    // Start is called before the first frame update
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            float RNGSpinTime = Random.Range(5f, 8f);
            MapSpin.StartSpinning(RNGSpinTime);

            Debug.Log("map rotate");
            Destroy(gameObject);
        }

    }
}
