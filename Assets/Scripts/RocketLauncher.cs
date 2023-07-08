using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
    public LogicScript Rocket;
    // Start is called before the first frame update
    void Start()
    {
        Rocket = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            Rocket.RocketStart();
            
            Debug.Log("Rocket ACTIVATED");
            Destroy(gameObject);
        }

    }
}
