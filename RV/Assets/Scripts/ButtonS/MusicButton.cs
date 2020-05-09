using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicButton : ButtonScript
{
    public RadioScript Radio;
    public bool next;
    public bool before;
    public bool mute;

    public override void ActiveAction()
    {
        if (next)
        {
            Radio.Next();
        }
        if (before)
        {
            Radio.Before();
        }
        if (mute)
        {
            Radio.Mute();
        }
        Debug.Log("Botón music activado");
    }
}
