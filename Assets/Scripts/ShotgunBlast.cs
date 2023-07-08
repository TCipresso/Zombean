using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunBlast : MonoBehaviour
{
    public float lifeTime;
    public int damage;
    public Rigidbody rb;

    private HashSet<GameObject> collidedObjects = new HashSet<GameObject>();

    private void Awake()
    {
        Destroy(gameObject, lifeTime);
        rb = GetComponent<Rigidbody>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zombean"))
        {
            if (!collidedObjects.Contains(other.gameObject))
            {
                collidedObjects.Add(other.gameObject);
                Enemy target = other.GetComponent<Enemy>();
                target.TakeDamage(damage);
            }
        }
        else if (other.gameObject.tag == "Player")
        {
            //rb.isKinematic = false;
            //Physics.IgnoreLayerCollision(6, 9, true);
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
        else if (other.gameObject.tag == "NorthSector")
        {
            //rb.isKinematic = false;
            //Physics.IgnoreLayerCollision(6, 9, true);
            //do nothing
        }
        else if (other.gameObject.tag == "SouthSector")
        {
            //rb.isKinematic = false;
            //Physics.IgnoreLayerCollision(6, 9, true);
            //do nothing
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
