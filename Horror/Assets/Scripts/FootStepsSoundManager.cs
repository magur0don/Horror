using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepsSoundManager : MonoBehaviour
{
    public AudioSource AudioSource;
    public AudioClip FootStepClip;

    public void PlayFootStepSE()
    {

        if (!AudioSource.isPlaying)
        {
            AudioSource.clip= FootStepClip;
            AudioSource.Play();
        }
    }
    public void StopFootStepSE()
    {
        AudioSource.Stop();
    }
}
