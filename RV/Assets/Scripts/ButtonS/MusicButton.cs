using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicButton : ButtonScript
{
    public RadioScript Radio;
    public bool next;
    public bool before;
    

    public new void ActiveAction()
    {
        if (next)
        {
            Radio.Next();
        }
        if (before)
        {

        }
        Debug.Log("Botón activado");
    }
}
