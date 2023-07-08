using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletBasicGun : MonoBehaviour
{
    // Start is called before the first frame update

    public float lifeTime = 3;
    public int damage;
    public GameObject explosionPrefab;
    void Awake()
    {
        Destroy(gameObject, lifeTime);
        //Physics.IgnoreLayerCollision(6, 9, true);
    }

    // Update is called once per frame


    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Zombean")
        {

            Enemy target = collision.gameObject.transform.gameObject.GetComponent<Enemy>();
            target.TakeDamage(damage);
            Destroy(gameObject);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            //Destroy(collision.gameObject);

        }
        else if(collision.gameObject.tag == "Player")
        {
            //Physics.IgnoreLayerCollision(6, 9, true);
        }
        else if (collision.gameObject.tag == "Bullet")
        {
            //Physics.IgnoreLayerCollision(6, 9, true);
            //do nothing
        }
        else if(collision.gameObject.tag == "Car")
        {
            CarHP target = collision.gameObject.transform.gameObject.GetComponent<CarHP>();
            target.TakeDamage(damage);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            Destroy(gameObject);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }
    }
}
