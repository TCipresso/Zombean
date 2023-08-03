using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerTrig : MonoBehaviour
{
    public CashShower Cash;
    // Start is called before the first frame update
    void Start()
    {
        Cash = GetComponent<CashShower>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Build"))
        {
            //Debug.Log("Build activated");
        }
        else if (other.CompareTag("Skull"))
        {
            //Debug.Log("Skull Activated");
        }
        else if (other.CompareTag("Money"))
        {
            Debug.Log("Money Activated");
            CashShower.Instance.Spawn();
        }
        else if (other.CompareTag("Star"))
        {
            //Debug.Log("Star Activated");
        }
        else if (other.CompareTag("Ex"))
        {
            //Debug.Log("Ex Activated");
        }
        else if (other.CompareTag("Question"))
        {
            //Debug.Log("Question Activated");
        }

    }


}
