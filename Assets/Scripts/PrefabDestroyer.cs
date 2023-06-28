using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * PrefabDestroyer is just a simple script I made for time purposes to destroy an object after 5 seconds. 
 * this was used for the barriers just so that it does not destroy fps overtime.
 */
public class PrefabDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        Destroy(gameObject, 5f);
    }
}
