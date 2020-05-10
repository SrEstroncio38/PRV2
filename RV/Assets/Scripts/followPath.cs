using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPath : MonoBehaviour
{

    public pathsParts ruta;
    private Transform[] waypoints;
    private pathsParts pathLeft;
    private pathsParts pathRight;
    private pathsParts pathForward;
    private pathsParts pathPrev;


    [SerializeField]
    private float moveSpeed = 0f;

    private int waypointIndex = 0;
    public bool goLeft = false;
    public bool goRight = false;

    Vector3 prevLoc;

    private void Start()
    {
        waypoints = ruta.GetComponent<pathsParts>().waypoints;
        pathLeft = ruta.GetComponent<pathsParts>().left;
        pathForward = ruta.GetComponent<pathsParts>().forward;
        pathRight = ruta.GetComponent<pathsParts>().right;
        pathPrev = ruta.GetComponent<pathsParts>().prev;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            moveSpeed += 1;
            if (moveSpeed > 3) moveSpeed = 3;
        }

        if (Input.GetKeyDown("s"))
        {
            moveSpeed -= 1;
            if (moveSpeed < -2) moveSpeed = -2;
        }

        if (Input.GetKeyDown("a"))
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

        if (Input.GetKeyDown("d"))
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

        if (moveSpeed > 0)
        {
            Move();
        }
        else if (moveSpeed < 0)
        {
            MoveBack();
        }

    }

    private void Move()
    {
        if (waypointIndex <= waypoints.Length - 1)
        {
            if (waypointIndex != 0)
                prevLoc = waypoints[waypointIndex - 1].transform.position;
            else
                prevLoc = transform.position;
            transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);
            //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(transform.position - prevLoc), Time.fixedDeltaTime * 1f);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(waypoints[waypointIndex].transform.position - prevLoc), 20 * Time.deltaTime * Mathf.Abs(moveSpeed));
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
                    ruta = pathRight;
                }
                else
                {
                    ruta = pathLeft;
                }
            }

            // Si no tengo camino a la derecha y lo tengo seleccionado
            else if (goRight && pathRight == null)
            {
                if (pathForward == null)
                {
                    ruta = pathLeft;
                }
            }

            // Si no tengo camino a la izquierda y lo tengo seleccionado
            else if (goLeft && pathLeft == null)
            {
                if (pathForward == null)
                {
                    ruta = pathRight;
                }
            }

            // Si tengo que realizar el giro normal horizontal
            else
            {
                if (!goRight && !goLeft)
                    ruta = pathForward;
                if (goRight)
                    ruta = pathRight;
                if (goLeft)
                    ruta = pathLeft;
            }

            waypoints = ruta.GetComponent<pathsParts>().waypoints;
            pathLeft = ruta.GetComponent<pathsParts>().left;
            pathForward = ruta.GetComponent<pathsParts>().forward;
            pathRight = ruta.GetComponent<pathsParts>().right;
            pathPrev = ruta.GetComponent<pathsParts>().prev;
            waypointIndex = 0;
        }

    }

    private void MoveBack()
    {
        if (waypointIndex > 0)
        {
            prevLoc = waypoints[waypointIndex - 1].transform.position;

            transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex-1].transform.position, Mathf.Abs(moveSpeed) * Time.deltaTime);
            //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(transform.position - prevLoc), Time.fixedDeltaTime * 1f);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(waypoints[waypointIndex].transform.position - prevLoc), 20 * Time.deltaTime * Mathf.Abs(moveSpeed));

            if (transform.position == waypoints[waypointIndex-1].transform.position)
            {
                waypointIndex -= 1;
            }
        }
        else
        {
            if (pathPrev != null)
            {
                ruta = pathPrev;
                waypoints = ruta.GetComponent<pathsParts>().waypoints;
                pathLeft = ruta.GetComponent<pathsParts>().left;
                pathForward = ruta.GetComponent<pathsParts>().forward;
                pathRight = ruta.GetComponent<pathsParts>().right;
                pathPrev = ruta.GetComponent<pathsParts>().prev;
                waypointIndex = waypoints.Length -1;
            }
        }
    }
}
