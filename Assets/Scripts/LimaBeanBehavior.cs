using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LimaBeanBehavior : MonoBehaviour
{
    // Start is called before the first frame update


    private Transform player;
    public Rigidbody rb;
    public int damage;

    private float Speed;
    //public float rotationSpeed = 500.0f;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
        Speed = Random.Range(3f, 6f);
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
        Vector3 direction = player.position - transform.position;
        //Quaternion lookRotation = Quaternion.LookRotation(direction);
       // Quaternion rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
        //transform.position += transform.forward * Speed * Time.deltaTime;
        transform.Translate(Vector3.forward * Time.deltaTime * Speed);
        //transform.rotation = Quaternion.Euler(0, 0, 0); // 0 0 0 

    }

    public void OnCollisionStay(Collision collision)
    {


        if (collision.collider.tag == "Wall")
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

        }
        



    }


}
