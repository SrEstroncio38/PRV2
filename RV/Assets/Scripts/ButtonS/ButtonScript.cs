using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{

    public GameObject hand;

    public float waitTime = 1.0f;

    private Vector3 originalPos;
    private Vector3 newPos;

    private bool activated = false;

    public float timer;
    
    void Start()
    {

        timer = waitTime;

        originalPos = transform.localPosition;
        newPos = originalPos + new Vector3(0.0f, -0.03f, 0.0f);


    }

    void Update()
    {
        timer += Time.deltaTime;
    }

    private void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.name == hand.name)
        {
            timer = 0;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {

        if (timer > waitTime)
        {

            if (collision.gameObject.name == hand.name)
            {
                if (!activated)
                {
                    activated = true;
                    transform.localPosition = newPos;
                    timer = 0;
                    ActiveAction();
                }
                else
                {
                    activated = false;
                    transform.localPosition = originalPos;
                    timer = 0;
                    InactiveAction();
                }
            }

        } else
        {
            timer = 0;
        }

    }

    public void ActiveAction()
    {
        Debug.Log("Botón activado");
    }

    private void InactiveAction()
    {
        Debug.Log("Botón desactivado");
    }

}
