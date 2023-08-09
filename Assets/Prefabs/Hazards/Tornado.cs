using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado : MonoBehaviour
{
    public float lifeTime;
    public int damage;

    // Start is called before the first frame update
    void Awake()
    {
        Destroy(gameObject, lifeTime);
        Physics.IgnoreLayerCollision(6, 9, true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zombean"))
        {

            Enemy target = other.GetComponent<Enemy>();
            target.TakeDamage(damage + 100);
            //Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Player")
        {
            //rb.isKinematic = false;
            //Physics.IgnoreLayerCollision(6, 9, true);
            PlayerStats player = other.GetComponent<PlayerStats>();
            player.TakeDamageP(damage);
        }
        else if (other.gameObject.tag == "Bullet")
        {
            //rb.isKinematic = false;
            //Physics.IgnoreLayerCollision(6, 9, true);
            //do nothing
        }
        else if (other.gameObject.tag == "PickUp")
        {
            //rb.isKinematic = false;
            //Physics.IgnoreLayerCollision(6, 9, true);
            //do nothing
        }
        else
        {
            //Destroy(gameObject);
        }

    }
}
