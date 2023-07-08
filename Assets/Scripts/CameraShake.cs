using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;


public class CameraShake : MonoBehaviour
{
    public Animator anim;
    public PlayerStats player;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (player.IsShake == true)
        {
            anim.Play("CamShake");
        }
    }

}


