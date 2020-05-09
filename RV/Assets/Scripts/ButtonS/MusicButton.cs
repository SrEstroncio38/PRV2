using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicButton : ButtonScript
{
    public RadioScript Radio;
    public bool next;
    public bool before;

    public void Start()
    {
 
    }

    public new void ActiveAction()
    {
        if (next)
        {
            Radio.Next();
        }
        if (before)
        {
            Radio.Before();
        }
        Debug.Log("Botón music activado");
    }
}
