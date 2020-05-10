using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaxonButton : ButtonScript
{
    public override void ActiveAction()
    {
        AudioSource claxon = GetComponentInChildren<AudioSource>();
        claxon.Play();
    }
}
