using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestTrigger : SoundsTrigger
{
    public override void modifySounds()
    {
        foreach (AudioSource a in Audios)
        {
            //Debug.Log("Cambiando Sonido de: " + a.clip.name);
            if (a.mute == true)
            {
                a.mute = false;
                if (!a.isPlaying)
                {
                    a.Play();
                }
            }
            else if (a.mute == false)
            {
                a.mute = true;
            }



        }
    }
}
