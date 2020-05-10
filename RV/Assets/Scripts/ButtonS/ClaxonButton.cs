using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaxonButton : ButtonScript
{

    public void Start()
    {
        timer = waitTime;

        originalPos = transform.localPosition;
        newPos = originalPos + new Vector3(0.0f, -0.03f, 0.0f);

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
