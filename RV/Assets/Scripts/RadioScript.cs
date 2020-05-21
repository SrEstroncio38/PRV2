using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class RadioScript : MonoBehaviour
{

    public List<AudioClip> Songs;
    private int nextSong = 1;
    private int currentS = 0;
    private float volume = 0;
    public TMP_Text currentSong;
    

    public void Start()
    {
        AudioSource radio = GetComponent<AudioSource>();
        
        string[] str = radio.clip.name.Split('-');
        currentSong.text = "<#ffffff>" + str[0] + "</color> - " + "<#40a0ff>" + str[1] + "</color>";
    }

    public void Update()
    {
        AudioSource radio = GetComponent<AudioSource>();
        if (!radio.isPlaying)
        {
            Next();
        }
    }


    public void Next()
    {
        //Debug.Log("Siguiente cancion");
        AudioSource radio = GetComponent<AudioSource>();
        radio.Stop();
        radio.clip = Songs[nextSong];
        radio.Play();
        string[] str = radio.clip.name.Split('-');
        currentSong.text = "<#ffffff>" + str[0] + "</color> - " + "<#40a0ff>" + str[1] + "</color>";
        nextSong++;
        currentS = nextSong - 1;
        if (nextSong >= Songs.Count)
        {
            nextSong = 0;
        }
        
    }

    public void Before()
    {
        //Debug.Log("Anterior cancion");
        AudioSource radio = GetComponent<AudioSource>();
        radio.Stop();
        currentS--;
        nextSong = currentS + 1;
        if(currentS < 0)
        {
            currentS = Songs.Count - 1;
            nextSong = 0;
        }
        radio.clip = Songs[currentS];
        radio.Play();
        string[] str = radio.clip.name.Split('-');
        currentSong.text = "<#ffffff>" + str[0] + "</color> - " + "<#40a0ff>" + str[1] + "</color>";
    }

    public void Mute()
    {
        //Debug.Log("Muteando");
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
