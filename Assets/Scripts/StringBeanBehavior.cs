using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StringBeanBehavior : MonoBehaviour
{
    // Start is called before the first frame update


    private Transform player;
    public Rigidbody rb;
    public int damage;
    public GameObject explosionPrefab;

    private float Speed;
    //public float rotationSpeed = 500.0f;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
        Speed = Random.Range(15f, 18f);
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
        Vector3 direction = player.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        // Quaternion rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
        //lookRotation *= Quaternion.Euler(-90, 0, 0);
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
        //transform.position += transform.forward * Speed * Time.deltaTime;
        transform.Translate(Vector3.forward * Time.deltaTime * Speed);
        //transform.rotation = Quaternion.Euler(0, 0, 0); // 0 0 0 

    }

    public void OnCollisionStay(Collision collision)
    {


        if (collision.collider.tag == "Wall" || collision.collider.tag == "Zombean")
        {
            //Debug.Log("wall collision");
            rb.isKinematic = false;
        }
        /*else if (collision.collider.tag == "Zombean")
        {
            rb.isKinematic = false;
        }*/
        else if (collision.collider.tag == "Player")
        {
            Debug.Log("player - 10");
            rb.isKinematic = true;
            PlayerStats playerS = collision.gameObject.transform.gameObject.GetComponent<PlayerStats>();
            playerS.TakeDamageP(damage);
            GameObject explosionInstance = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }



    }


}
