using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemaTrigger : SoundsTrigger
{
    public Cinema Cine;

    public override void modifySounds()
    {
        Cine.StopVideos();
    }
}
