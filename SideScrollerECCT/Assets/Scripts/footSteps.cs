using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class footSteps : MonoBehaviour
{
    public AudioClip[] ftStepsAudio = new AudioClip[5];
    public AudioSource playerAudio;
    

    private void Awake()
    {
        playerAudio = GetComponent<AudioSource>();
    }

    private void footStepsAudio()
    {
        if (gameObject.GetComponent<PlayerMove>()._isGround && Input.GetAxis("Horizontal") != 0)
        {
            System.Random rnd = new System.Random();
            playerAudio.PlayOneShot(ftStepsAudio[rnd.Next(0, 5)]);
        }
    }    
}
