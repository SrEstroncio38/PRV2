using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class MusicButton : ButtonScript
{
    public RadioScript Radio;
    public bool next;
    public bool before;
    public bool mute;
    public GameObject planoAct;
    public GameObject planoDes;

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
            if (planoAct.activeSelf == true)
            {
                planoAct.SetActive(false);
                planoDes.SetActive(true);
            }
            else
            {
                planoAct.SetActive(true);
                planoDes.SetActive(false);
            }
            Radio.Mute();
        }
        //Debug.Log("Botón music activado");
    }
}
