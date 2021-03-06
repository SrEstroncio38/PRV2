﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPath : MonoBehaviour
{

    public pathsParts ruta;
    private Transform[] waypoints;
    private pathsParts pathLeft;
    private pathsParts pathRight;
    private pathsParts pathForward;
    private pathsParts pathPrevForward;
    private pathsParts pathPrevLeft;
    private pathsParts pathPrevRight;

    [SerializeField]
    public float moveSpeed = 0f;
    public float keepSpeed = 0f;
    public float signSpeed = 0f;
    [SerializeField]
    public float velocityStep = 0f;
    [SerializeField]
    private float turnSpeed = 0f;
    [SerializeField]
    private float maxSpeedForw = 0f;
    [SerializeField]
    private float maxSpeedBack = 0f;

    [SerializeField]
    private int waypointIndex = 0;
    [SerializeField]
    private int direccionMov = 1;
    public bool goLeft = false;
    public bool goRight = false;

    Vector3 prevLoc;

    private void Start()
    {
        waypoints = ruta.GetComponent<pathsParts>().waypoints;
        pathLeft = ruta.GetComponent<pathsParts>().left;
        pathForward = ruta.GetComponent<pathsParts>().forward;
        pathRight = ruta.GetComponent<pathsParts>().right;

        pathPrevLeft = ruta.GetComponent<pathsParts>().prevLeft;
        pathPrevForward = ruta.GetComponent<pathsParts>().prevForward;
        pathPrevRight = ruta.GetComponent<pathsParts>().prevRight;
    }

    // Update is called once per frame
    private void Update()
    {
        /*
        if (Input.GetKeyDown("w"))
        {
            PressForward();
        }

        if (Input.GetKeyDown("s"))
        {
            PressBackward();
        }

        if (Input.GetKeyDown("a"))
        {
            PressLeft();
        }

        if (Input.GetKeyDown("d"))
        {
            PressRight();
        }
        */

        if (keepSpeed != 0) moveSpeed = keepSpeed;

        if (moveSpeed > 0)
        {
            if (direccionMov == 1)
                Move();
            else
                MoveForwardBack();
        }
        else if (moveSpeed < 0)
        {
            if (direccionMov == 1)
                MoveBack();
            else
                MoveBackBack();
        }
    }

    public void PressForward()
    {
        moveSpeed += velocityStep;
        if (moveSpeed > maxSpeedForw) moveSpeed = maxSpeedForw;
    }

    public void PressBackward()
    {
        moveSpeed -= velocityStep;
        if (moveSpeed < -maxSpeedBack) moveSpeed = -maxSpeedBack;
    }

    public void PressLeft()
    {
        if (goLeft == true)
        {
            goLeft = false;
        }
        else
        {
            goLeft = true;
        }
        goRight = false;
    }

    public void PressRight()
    {
        if (goRight == true)
        {
            goRight = false;
        }
        else
        {
            goRight = true;
        }
        goLeft = false;
    }

    private void Move()
    {
        // Si ejecuto el camino en el orden que está creado
        if (waypointIndex <= waypoints.Length - 1)
        {
            if (waypointIndex != 0)
                prevLoc = waypoints[waypointIndex - 1].transform.position;
            else
                prevLoc = transform.position;
            transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);
            //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(transform.position - prevLoc), Time.fixedDeltaTime * 1f);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(waypoints[waypointIndex].transform.position - prevLoc), turnSpeed * Time.deltaTime * Mathf.Abs(moveSpeed));
            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
            }
        }
        else
        {
            // Si no tengo un camino recto y no he decidido ningún camino
            if (!goLeft && !goRight && pathForward == null)
            {
                if (pathLeft == null)
                {
                    direccionMov = ruta.rightDirection;
                    ruta = pathRight;
                }
                else
                {
                    direccionMov = ruta.leftDirection;
                    ruta = pathLeft;
                }
            }

            // Si no tengo camino a la derecha y lo tengo seleccionado
            else if (goRight && pathRight == null)
            {
                if (pathForward == null)
                {
                    direccionMov = ruta.leftDirection;
                    ruta = pathLeft;
                }
                else
                {
                    direccionMov = ruta.forwardDirection;
                    ruta = pathForward;
                }
            }

            // Si no tengo camino a la izquierda y lo tengo seleccionado
            else if (goLeft && pathLeft == null)
            {
                if (pathForward == null)
                {
                    direccionMov = ruta.rightDirection;
                    ruta = pathRight;
                }
                else
                {
                    direccionMov = ruta.forwardDirection;
                    ruta = pathForward;
                }
            }

            // Si tengo que realizar el giro normal horizontal
            else
            {
                if (!goRight && !goLeft)
                {
                    direccionMov = ruta.forwardDirection;
                    ruta = pathForward;
                }
                if (goRight)
                {
                    direccionMov = ruta.rightDirection;
                    ruta = pathRight;
                }
                if (goLeft)
                {
                    direccionMov = ruta.leftDirection;
                    ruta = pathLeft;
                }
            }

            // Nuevos waypoints
            waypoints = ruta.GetComponent<pathsParts>().waypoints;

            pathLeft = ruta.GetComponent<pathsParts>().left;
            pathForward = ruta.GetComponent<pathsParts>().forward;
            pathRight = ruta.GetComponent<pathsParts>().right;

            pathPrevLeft = ruta.GetComponent<pathsParts>().prevLeft;
            pathPrevForward = ruta.GetComponent<pathsParts>().prevForward;
            pathPrevRight = ruta.GetComponent<pathsParts>().prevRight;
            if (direccionMov == 1)
                waypointIndex = 0;
            else
                waypointIndex = waypoints.Length - 1;
        }
    }

    private void MoveForwardBack()
    {
        if (waypointIndex > 0)
        {
            prevLoc = waypoints[waypointIndex - 1].transform.position;

            transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex - 1].transform.position, Mathf.Abs(moveSpeed) * Time.deltaTime);
            //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(transform.position - prevLoc), Time.fixedDeltaTime * 1f);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(prevLoc - waypoints[waypointIndex].transform.position), turnSpeed * Time.deltaTime * Mathf.Abs(moveSpeed));

            if (transform.position == waypoints[waypointIndex - 1].transform.position)
            {
                waypointIndex -= 1;
            }
        }
        else
        {
            // Si no tengo un camino recto y no he decidido ningún camino
            if (!goLeft && !goRight && pathPrevForward == null)
            {
                if (pathPrevLeft == null)
                {
                    direccionMov = ruta.prevRightDirection;
                    ruta = pathPrevRight;
                }
                else
                {
                    direccionMov = ruta.prevLeftDirection;
                    ruta = pathPrevLeft;
                }
            }

            // Si no tengo camino a la derecha y lo tengo seleccionado
            else if (goRight && pathPrevRight == null)
            {
                if (pathPrevForward == null)
                {
                    direccionMov = ruta.prevLeftDirection;
                    ruta = pathPrevLeft;
                }
                else
                {
                    direccionMov = ruta.prevForwardDirection;
                    ruta = pathPrevForward;
                }
            }

            // Si no tengo camino a la izquierda y lo tengo seleccionado
            else if (goLeft && pathPrevLeft == null)
            {
                if (pathPrevForward == null)
                {
                    direccionMov = ruta.prevRightDirection;
                    ruta = pathPrevRight;
                }
                else
                {
                    direccionMov = ruta.prevForwardDirection;
                    ruta = pathPrevForward;
                }
            }

            // Si tengo que realizar el giro normal horizontal
            else
            {
                if (!goRight && !goLeft)
                {
                    direccionMov = ruta.prevForwardDirection;
                    ruta = pathPrevForward;
                }
                if (goRight)
                {
                    direccionMov = ruta.prevRightDirection;
                    ruta = pathPrevRight;
                }
                if (goLeft)
                {
                    direccionMov = ruta.prevLeftDirection;
                    ruta = pathPrevLeft;
                }
            }

            // Nuevos waypoints
            waypoints = ruta.GetComponent<pathsParts>().waypoints;

            pathLeft = ruta.GetComponent<pathsParts>().left;
            pathForward = ruta.GetComponent<pathsParts>().forward;
            pathRight = ruta.GetComponent<pathsParts>().right;

            pathPrevLeft = ruta.GetComponent<pathsParts>().prevLeft;
            pathPrevForward = ruta.GetComponent<pathsParts>().prevForward;
            pathPrevRight = ruta.GetComponent<pathsParts>().prevRight;

            if (direccionMov == 1)
                waypointIndex = 0;
            else
                waypointIndex = waypoints.Length - 1;
        }
    }

    private void MoveBack()
    {
        if (waypointIndex > 0)
        {
            prevLoc = waypoints[waypointIndex - 1].transform.position;

            transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex - 1].transform.position, Mathf.Abs(moveSpeed) * Time.deltaTime);
            //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(transform.position - prevLoc), Time.fixedDeltaTime * 1f);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(waypoints[waypointIndex].transform.position - prevLoc), turnSpeed * Time.deltaTime * Mathf.Abs(moveSpeed));

            if (transform.position == waypoints[waypointIndex - 1].transform.position)
            {
                waypointIndex -= 1;
            }
        }
        else
        {
            // Si no tengo un camino recto y no he decidido ningún camino
            if (!goLeft && !goRight && pathPrevForward == null)
            {
                if (pathPrevRight == null)
                {
                    direccionMov = ruta.prevLeftDirection;
                    ruta = pathPrevLeft;
                }
                else
                {
                    direccionMov = ruta.prevRightDirection;
                    ruta = pathPrevRight;
                }
            }

            // Si no tengo camino a la derecha y lo tengo seleccionado
            else if (goRight && pathPrevLeft == null)
            {
                if (pathPrevForward == null)
                {
                    direccionMov = ruta.prevRightDirection;
                    ruta = pathPrevRight;
                }
                else
                {
                    direccionMov = ruta.prevForwardDirection;
                    ruta = pathPrevForward;
                }
            }

            // Si no tengo camino a la izquierda y lo tengo seleccionado
            else if (goLeft && pathPrevRight == null)
            {
                if (pathPrevForward == null)
                {
                    direccionMov = ruta.prevLeftDirection;
                    ruta = pathPrevLeft;
                }
                else
                {
                    direccionMov = ruta.prevForwardDirection;
                    ruta = pathPrevForward;
                }
            }

            // Si tengo que realizar el giro normal horizontal
            else
            {
                if (!goRight && !goLeft)
                {
                    direccionMov = ruta.prevForwardDirection;
                    ruta = pathPrevForward;
                }
                if (goRight)
                {
                    direccionMov = ruta.prevLeftDirection;
                    ruta = pathPrevLeft;
                }
                if (goLeft)
                {
                    direccionMov = ruta.prevRightDirection;
                    ruta = pathPrevRight;
                }
            }

            // Nuevos waypoints
            waypoints = ruta.GetComponent<pathsParts>().waypoints;

            pathLeft = ruta.GetComponent<pathsParts>().left;
            pathForward = ruta.GetComponent<pathsParts>().forward;
            pathRight = ruta.GetComponent<pathsParts>().right;

            pathPrevLeft = ruta.GetComponent<pathsParts>().prevLeft;
            pathPrevForward = ruta.GetComponent<pathsParts>().prevForward;
            pathPrevRight = ruta.GetComponent<pathsParts>().prevRight;

            if (direccionMov == 1)
            {
                direccionMov = -1;
                waypointIndex = 0;
            }
            else
            {
                direccionMov = 1;
                waypointIndex = waypoints.Length - 1;
            }

        }
    }

    private void MoveBackBack()
    {
        if (waypointIndex <= waypoints.Length - 1)
        {
            if (waypointIndex != 0)
                prevLoc = waypoints[waypointIndex - 1].transform.position;
            else
                prevLoc = transform.position;
            transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, Mathf.Abs(moveSpeed) * Time.deltaTime);
            //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(transform.position - prevLoc), Time.fixedDeltaTime * 1f);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(prevLoc - waypoints[waypointIndex].transform.position), turnSpeed * Time.deltaTime * Mathf.Abs(moveSpeed));
            
            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
            }
        }
        else
        {
            // Si no tengo un camino recto y no he decidido ningún camino
            if (!goLeft && !goRight && pathForward == null)
            {
                if (pathRight == null)
                {
                    direccionMov = ruta.leftDirection;
                    ruta = pathLeft;
                }
                else
                {
                    direccionMov = ruta.rightDirection;
                    ruta = pathRight;
                }
            }

            // Si no tengo camino a la derecha y lo tengo seleccionado
            else if (goRight && pathLeft == null)
            {
                if (pathForward == null)
                {
                    direccionMov = ruta.rightDirection;
                    ruta = pathRight;
                }
                else
                {
                    direccionMov = ruta.forwardDirection;
                    ruta = pathForward;
                }
            }

            // Si no tengo camino a la izquierda y lo tengo seleccionado
            else if (goLeft && pathRight == null)
            {
                if (pathForward == null)
                {
                    direccionMov = ruta.leftDirection;
                    ruta = pathLeft;
                }
                else
                {
                    direccionMov = ruta.forwardDirection;
                    ruta = pathForward;
                }
            }

            // Si tengo que realizar el giro normal horizontal
            else
            {
                if (!goRight && !goLeft)
                {
                    direccionMov = ruta.forwardDirection;
                    ruta = pathForward;
                }
                if (goRight)
                {
                    direccionMov = ruta.leftDirection;
                    ruta = pathLeft;
                }
                if (goLeft)
                {
                    direccionMov = ruta.rightDirection;
                    ruta = pathRight;
                }
            }

            // Nuevos waypoints
            waypoints = ruta.GetComponent<pathsParts>().waypoints;

            pathLeft = ruta.GetComponent<pathsParts>().left;
            pathForward = ruta.GetComponent<pathsParts>().forward;
            pathRight = ruta.GetComponent<pathsParts>().right;

            pathPrevLeft = ruta.GetComponent<pathsParts>().prevLeft;
            pathPrevForward = ruta.GetComponent<pathsParts>().prevForward;
            pathPrevRight = ruta.GetComponent<pathsParts>().prevRight;
            
            if (direccionMov == 1)
            {
                direccionMov = -1;
                waypointIndex = 0;
            }
            else
            {
                direccionMov = 1;
                waypointIndex = waypoints.Length - 1;
            }
        }
    }
}
