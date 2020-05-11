using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathsParts : MonoBehaviour
{
    public Transform[] waypoints;

    [Header("Adelante")]
    public pathsParts left = null;
    public int leftDirection = 1;
    public pathsParts forward = null;
    public int forwardDirection = 1;
    public pathsParts right = null;
    public int rightDirection = 1;

    [Header("Atrás")]
    public pathsParts prevLeft = null;
    public int prevLeftDirection = 1;
    public pathsParts prevForward = null;
    public int prevForwardDirection = 1;
    public pathsParts prevRight = null;
    public int prevRightDirection = 1;

}
