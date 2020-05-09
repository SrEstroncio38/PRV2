using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{

    public GameObject hand;

    public bool oneTimePress = true;

    public float waitTime = 1.0f;

    public List<ButtonScript> deactivatedButtons;

    protected Vector3 originalPos;
    protected Vector3 newPos;

    protected bool activated = false;

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

        if (oneTimePress && timer > waitTime && activated)
        {
            TriggerDeactivation(false);
        }
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
                    TriggerActivation();
                }
                else if (!oneTimePress)
                {
                    TriggerDeactivation();
                }
            }

        } else
        {
            timer = 0;
        }

    }

    public void TriggerActivation()
    {
        activated = true;
        transform.localPosition = newPos;
        timer = 0;
        foreach (ButtonScript b in deactivatedButtons)
        {
            b.TriggerDeactivation();
        }
        ActiveAction();
    }

    public void TriggerDeactivation(bool resetTimer = true)
    {
        activated = false;
        transform.localPosition = originalPos;
        if (resetTimer)
            timer = 0;
        InactiveAction();
    }

    public virtual void ActiveAction()
    {
        Debug.Log("Botón activado");
    }

    public virtual void InactiveAction()
    {
        Debug.Log("Botón desactivado");
    }

}
