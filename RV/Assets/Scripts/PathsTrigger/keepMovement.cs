using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keepMovement : pathTrigger
{
    public float speedFall;
    public override void modifyMovement(Collider collision)
    {
        followPath wagon = collision.gameObject.GetComponentInParent<followPath>();
        wagon.keepSpeed = Mathf.Sign(wagon.moveSpeed) * speedFall;
    }
}
