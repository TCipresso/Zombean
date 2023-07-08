using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashPickUp : MonoBehaviour
{
    public LogicScript Cash;
    // Start is called before the first frame update
    void Start()
    {
        Cash = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        Destroy(gameObject, 8.4f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            Cash.AddPoints();

            Debug.Log("Cash added");
            Destroy(gameObject);
        }

    }
}
