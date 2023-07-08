using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZaWarudo : MonoBehaviour
{
    public TimeStop Stop;
    // Start is called before the first frame update
    void Start()
    {
        Stop = GameObject.FindGameObjectWithTag("Stop").GetComponent<TimeStop>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //CODLogic codLogic = COD.GetComponent<CODLogic>();
            //codLogic.StartCOD(1f);
            // ActivateCOD();


            //Stop.MiniStart();
            StartCoroutine(Stop.StartStopTime());
            Debug.Log("ZA WAURDO");
            Destroy(gameObject);
        }

    }
}
