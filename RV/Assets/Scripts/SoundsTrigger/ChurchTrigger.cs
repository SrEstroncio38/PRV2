using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChurchTrigger : SoundsTrigger
{
   public override void modifySounds()
    {        
        foreach (AudioSource a in Audios)
        {

            if(a.mute == true)
            {
                if(a.volume == 0)
                {
                    a.mute = false;
                    a.volume = 0.8f;
                    a.Play();
                } 
                
            }
            
        }

    }
}
