using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioScript : MonoBehaviour
{

    public List<AudioClip> Songs;
    private int nextSong = 1;
    
    public void Next()
    {
        AudioSource radio = GetComponent<GameObject>().GetComponent<AudioSource>();
        radio.Stop();
        radio.clip = Songs[nextSong];
        radio.Play();
        nextSong++;
        if(nextSong >= Songs.Count)
        {
            nextSong = 0;
        }
    }
}
