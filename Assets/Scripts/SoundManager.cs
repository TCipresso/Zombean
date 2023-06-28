using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * SoundManager manages the sounds of the game. 
 * Can be used for music, but I mainly used for the triggering the SFX.
 */
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource Audio1;
    public AudioSource Audio2;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this; // made instance for sounds mainly for the trigger SFX.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
