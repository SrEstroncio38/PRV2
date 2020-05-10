using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaxonButton : ButtonScript
{
    public AudioSource claxon;

    public override void ActiveAction()
    { 
        claxon.Play();
    }
}
