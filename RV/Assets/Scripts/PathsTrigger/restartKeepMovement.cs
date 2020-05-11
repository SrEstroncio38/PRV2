using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restartKeepMovement : pathTrigger
{
    public float restartSpeed = 5.0f;
    public override void modifyMovement(Collider collision)
    {
        followPath wagon = collision.gameObject.GetComponentInParent<followPath>();
        if (wagon.keepSpeed != 0f)
        {
            wagon.keepSpeed = 0f;
            wagon.moveSpeed = restartSpeed;
        }
    }
}
