using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
[SerializeField] AudioClip woodCrash;
[SerializeField] AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayWoodCrash()
    {
        audioSource.PlayOneShot(woodCrash);
    }
}
