using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossBehavior : MonoBehaviour
{
    // Start is called before the first frame update

    public CameraShake anim;
    private Transform player;
    public Rigidbody rb;
    public int damage;


    private float Speed;
    private CameraShake Shake;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
        Speed = Random.Range(6f, 10f);
        Physics.IgnoreLayerCollision(7, 7, true);


    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
        //transform.position += transform.forward * Speed * Time.deltaTime;
        transform.Translate(Vector3.forward * Time.deltaTime * Speed);
        transform.rotation = Quaternion.Euler(0, 0, 0);

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
