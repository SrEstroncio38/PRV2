using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathTrigger : MonoBehaviour
{
    public GameObject trigger;
    public void OnTriggerEnter(Collider collision)
    {
        //Debug.Log("He colisionado con algo");
        if (collision.gameObject.name == trigger.name)
        {
            modifyMovement(collision);
        }
    }

    public virtual void modifyMovement(Collider collision){}
}
