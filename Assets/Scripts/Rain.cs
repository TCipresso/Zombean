using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    public float speed; 
    public float DropTime;


    void Update()
    {


        StartCoroutine(RainOnMe());
        

    }
    
    public IEnumerator RainOnMe()
    {
        transform.position += -transform.up * speed * Time.deltaTime;
        yield return new WaitForSecondsRealtime(DropTime);
        speed = 0;
    }

}
