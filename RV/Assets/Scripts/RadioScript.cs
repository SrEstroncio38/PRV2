using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioScript : MonoBehaviour
{

    public List<AudioClip> Songs;
    private int nextSong = 1;
    

    public void Start()
    {

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
            nextSong = Songs.Count;
        }
        radio.clip = Songs[nextSong];
        radio.Play();
    }
    
}
