using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaxonButton : ButtonScript
{
    public AudioSource claxon;

    public void Awake()
    {
        claxon.mute = true;
    }

    public override void ActiveAction()
    {
        claxon.mute = false;
        claxon.Play();
    }
}
