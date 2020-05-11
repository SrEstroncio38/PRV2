using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restartStopMovement : pathTrigger
{
    public override void modifyMovement(Collider collision)
    {
        followPath wagon = collision.gameObject.GetComponentInParent<followPath>();
        wagon.signSpeed = 0f;
    }
}
