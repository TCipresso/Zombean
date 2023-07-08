using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleOFDeath : MonoBehaviour
{
    
    public LogicScript Circ;


    void Start()
    {
         Circ = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //CODLogic codLogic = COD.GetComponent<CODLogic>();
            //codLogic.StartCOD(1f);
            // ActivateCOD();
            
            
            Circ.StartCirc();
            
            Debug.Log("COD ACTIVATED");
            Destroy(gameObject);
        }

    }
    



    /*private void ActivateCOD()
    {
        COD.SetActive(true);
        StartCoroutine(DeactivateCODAfterDelay(5f));
    }

    private IEnumerator)
    {
        yield return new WaitForSeconds(delay);
        COD.SetActive(false);
        Debug.Log("COD DEACTIVATED");
    }*/
}
