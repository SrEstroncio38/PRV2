using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointableObject : MonoBehaviour
{

    public float waitTime = 3.0f;
    public bool beingHit = false;

    private bool isActive;
    private float currentTime;
    private float offsetTime;

    // Start is called before the first frame update
    void Start()
    {

        currentTime = 0.0f;
        offsetTime = 1.0f;

        isActive = false;
        beingHit = false;
        
    }

    // Update is called once per frame
    void Update()
    {

        if (beingHit)
            currentTime += Time.deltaTime;
        else
            currentTime -= Time.deltaTime * 0.75f;

        if (currentTime < 0)
        {
            currentTime = 0;
            if (isActive)
                isActive = false;
        }

        if (currentTime > offsetTime && isActive)
            currentTime = offsetTime;

        if (currentTime > waitTime && !isActive)
        {
            isActive = true;
            currentTime = offsetTime;
            PerformAction();
        }

        beingHit = false;
        
    }

    private void PerformAction ()
    {
        Debug.Log("Activado por el rayo");
    }

}
