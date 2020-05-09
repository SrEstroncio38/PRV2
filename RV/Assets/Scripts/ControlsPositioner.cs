using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsPositioner : MonoBehaviour
{

    public Transform target;
    public float smoothTime = 0.2F;
    private float turningRate;
    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        turningRate = 180 / smoothTime;
    }

    void Update()
    {
        Vector3 targetPosition = target.position;
        Quaternion targetRotation = target.rotation;
        
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turningRate * Time.deltaTime);
    }
}
