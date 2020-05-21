using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniTrigger : SoundsTrigger
{
    public List<RandomFlyingObject> Randoms;
    public bool muteador;

    public override void modifySounds()
    {
        foreach (RandomFlyingObject a in Randoms)
        {
            if (muteador)
            {
                a.muted = true;
            } else
            {
                a.muted = false;
            }
    

        }
    }
}
