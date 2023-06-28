using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * NegativeNumbers is entirely meant to handle the trigger for the red boxes.
 * in hindsight I should have organized the box triggers better, but this worked fine.
 */
public class NegativeNumbers : MonoBehaviour
{
    public AudioSource Audio;
    public MenuLogic ML;
    public GameObject MusicManager;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);
        ML = GameObject.FindGameObjectWithTag("GameController").GetComponent<MenuLogic>();
        //Audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)//this for the red boxes.
    {
        if(collision.tag == "Player")
        {
            Debug.Log("SPEND");
            SoundManager.instance.Audio2.Play();//play SFX
            ML.Score();//when player hits the box update the score.
            
            Destroy(gameObject);//destroy after contact with player.
        }
    }
}
