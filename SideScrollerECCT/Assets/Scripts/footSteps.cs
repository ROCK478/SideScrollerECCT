using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footSteps : MonoBehaviour
{
    public AudioClip[] ftStepsAudio = new AudioClip[5];
    public AudioSource playerAudio;

    private int numAudion = 0;

    private void Awake()
    {
        playerAudio = GetComponent<AudioSource>();
    }

    private void footStepsAudio()
    {
        playerAudio.PlayOneShot(ftStepsAudio[numAudion]);
        numAudion++;

        if (numAudion >= ftStepsAudio.Length) { numAudion = 0; }
    }    
}
