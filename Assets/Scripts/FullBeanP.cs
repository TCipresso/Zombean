using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullBeanP : MonoBehaviour
{
    public LogicScript Full;
    // Start is called before the first frame update
    void Start()
    {
        Full = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //CODLogic codLogic = COD.GetComponent<CODLogic>();
            //codLogic.StartCOD(1f);
            // ActivateCOD();


            Full.FullBeanStart();

            Debug.Log("Full bean ACTIVATED");
            Destroy(gameObject);
        }

    }
}
