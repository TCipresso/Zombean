using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public LogicScript Shotty;
    // Start is called before the first frame update
    void Start()
    {
        Shotty = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //CODLogic codLogic = COD.GetComponent<CODLogic>();
            //codLogic.StartCOD(1f);
            // ActivateCOD();


            Shotty.ShottyStart();

            Debug.Log("Shotgun ACTIVATED");
            Destroy(gameObject);
        }

    }
}
