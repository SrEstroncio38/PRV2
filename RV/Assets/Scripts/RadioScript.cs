using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioScript : MonoBehaviour
{

    public List<AudioClip> Songs;
    private int nextSong = 1;
    private float volume = 0;
    

    public void Start()
    {
        Mute();
    }

    public void Update()
    {
        
    }

    public void Next()
    {
        Debug.Log("Siguiente cancion");
        AudioSource radio = GetComponent<AudioSource>();
        radio.Stop();
        radio.clip = Songs[nextSong];
        radio.Play();
        nextSong++;
        if(nextSong >= Songs.Count)
        {
            nextSong = 0;
        }
        
    }

    public void Before()
    {
        Debug.Log("Anterior cancion");
        AudioSource radio = GetComponent<AudioSource>();
        radio.Stop();
        nextSong--;
        if(nextSong < 0)
        {
            nextSong = Songs.Count - 1;
        }
        radio.clip = Songs[nextSong];
        radio.Play();
    }

    public void Mute()
    {
        Debug.Log("Muteando");
        AudioSource radio = GetComponent<AudioSource>();
        if(radio.mute)
        {
            radio.mute = false;
        } else
        {
            radio.mute = true;
        }
    }
    
}
