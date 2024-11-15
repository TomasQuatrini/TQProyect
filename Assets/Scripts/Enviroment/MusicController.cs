using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioSource musicSource; // Referencia al objeto de audio de la música

    void Start()
    {
        musicSource = GetComponent<AudioSource>();
        musicSource.loop = true; // Activa el bucle
        musicSource.volume = 0.5f; // Ajusta el volumen
        musicSource.Play(); // Reproduce la música de fondo
    }
}
