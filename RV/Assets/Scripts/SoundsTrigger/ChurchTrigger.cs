using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChurchTrigger : SoundsTrigger
{
   public override void modifySounds()
    {

        foreach (AudioSource a in Audios)
        {
            a.mute = false;
            a.Play();
        }

    }
}
