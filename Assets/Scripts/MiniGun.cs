using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGun : MonoBehaviour
{
    public LogicScript Mini;
    // Start is called before the first frame update
    void Start()
    {
        Mini = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //CODLogic codLogic = COD.GetComponent<CODLogic>();
            //codLogic.StartCOD(1f);
            // ActivateCOD();


            Mini.MiniStart();

            Debug.Log("Mini Gun ACTIVATED");
            Destroy(gameObject);
        }

    }
}
