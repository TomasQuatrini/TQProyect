using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
public AudioClip woodCrash;
private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayWoodCrash()
    {
        audioSource.PlayOneShot(woodCrash);
    }
}
