using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsTrigger : MonoBehaviour
{
    public List<AudioSource> Audios;
    public List<AudioSource> AudiosToActive;
    public GameObject trigger;

    public void OnTriggerEnter(Collider collision)
    {
        //Debug.Log("He colisionado con algo");
        if (collision.gameObject.name == trigger.name)
        {
            modifySounds();
        }
    }

    public virtual void modifySounds()
    {

    }
}
