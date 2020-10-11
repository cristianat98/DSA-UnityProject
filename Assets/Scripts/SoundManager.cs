using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;
    public AudioSource fondo;
    public AudioSource mercadona;
    public AudioSource contagiado;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (!mercadona.isPlaying)
            fondo.volume = 1f;
    }

    public void contagiar()
    {
        if (fondo.isPlaying)
        {
            fondo.Stop();
            contagiado.Play();
        }
    }

    public void curar()
    {
        contagiado.Stop();
        fondo.Play();
    }

    public void sonidomercadona()
    {
        if (fondo.isPlaying)
            fondo.volume = 0.2f;

        mercadona.Play();
    }

    public void gameover()
    {
        if (!contagiado.isPlaying)
        {
            fondo.Stop();
            contagiado.Play();
        }

    }
}
