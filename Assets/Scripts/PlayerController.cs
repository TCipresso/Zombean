using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/*
 * PlayerController handles control of the player as well as soem interactions such as triggers.
 * This script allows player to move at the rigid angles I wanted to make it look like a stock arrows flow. 
 * Uses A and D to change direction.
 * Saves last direction with a simple variable.
 */
public class PlayerController : MonoBehaviour
{
    public float dodgeDistance; // Distance to dodge
    public float downwardSpeed; // Constant downward speed
    private Rigidbody2D rb; 
    private float lastDirection = 1f; // Last direction moved
    public MenuLogic ML;

    


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); 
        ML = GameObject.FindGameObjectWithTag("GameController").GetComponent<MenuLogic>();

    }

    void Update()
    {

        

        if (Input.GetKey(KeyCode.A)) 
        {
            Debug.Log("Pressing A");
            Move(-dodgeDistance); // Dodge to the left
            transform.eulerAngles = new Vector3(0, 0, -15);// this is what gives the player that angle like movement.
            lastDirection = -1f;
        }
        else if (Input.GetKey(KeyCode.D)) 
        {
            Debug.Log("Pressing D");
            Move(dodgeDistance); // Dodge to the right
            transform.eulerAngles = new Vector3(0, 0, 70);//this is what gives the player that angle like movement.
            lastDirection = 1f;
        }

        Move(lastDirection * dodgeDistance); // Constantly move based on what is the last saved direction or lasst direction pressed.
    
        
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(rb.velocity.x, -downwardSpeed); // Sets a constant downward speed for the camera holder to constantly be moving down.
    }//this i put on the camera holder that contains the main cam, as well as the spawners so that it constantly goes down.

    void Move(float distance)
    { //this Vector3 this constantly pushes player down no matter the sign of "distance" with this player will always move downward at the samerate.
        Vector3 newPosition = new Vector3(transform.position.x + distance, transform.position.y - Mathf.Abs(distance), transform.position.z);//originally was going to use gravity however it has acceleration that was way too fast.
        rb.MovePosition(newPosition);//moves rigidboyd based on newPosition.

       
    }

    private void OnTriggerEnter2D(Collider2D collision)//this trigger is for when the player hits the green box they die and the game over to main menu coroutines start.
    {
        if (collision.tag == "Green")
        {
            Debug.Log("GREEN");
            ML.GameOverToMain();
            ML.GameOverScreen.SetActive(true);
            Destroy(gameObject);
            
            
        }
    }


}
