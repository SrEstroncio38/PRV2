using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopMovement : MonoBehaviour
{

    public GameObject trigger;

    public void OnTriggerStay(Collider collision)
    {
        followPath wagon = collision.gameObject.GetComponentInParent<followPath>();
        if (collision.gameObject.name == trigger.name)
        {
            if (wagon.signSpeed == 0)
            {
                wagon.signSpeed = Mathf.Sign(wagon.moveSpeed);
            }
            if (wagon.moveSpeed != 0)
            {
                if (wagon.signSpeed != Mathf.Sign(wagon.moveSpeed))
                {
                    wagon.moveSpeed = 0;
                }
            }
        }
    }
}
