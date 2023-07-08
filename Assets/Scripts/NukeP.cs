using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukeP : MonoBehaviour
{
    public NUKE nukes;
    // Start is called before the first frame update
    void Start()
    {
        nukes = GameObject.FindGameObjectWithTag("nukes").GetComponent<NUKE>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            nukes.Spawn();

            Debug.Log("Nuke spawned");
            Destroy(gameObject);
        }

    }
}
