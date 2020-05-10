using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaxonButton : ButtonScript
{

    public void Start()
    {
        AudioSource claxon = GetComponentInChildren<AudioSource>();
        claxon.mute = true;
    }
    public override void ActiveAction()
    {
        AudioSource claxon = GetComponentInChildren<AudioSource>();
        claxon.mute = false;
        claxon.Play();
    }
}
