using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class wagonMovement : MonoBehaviour
{

    int speedForward = 0;
    public bool goLeft = false;
    public bool goRight = false;
    public Quaternion giro;
    public Quaternion preGiro;

    public bool forwardCollider = false;
    public bool leftCollider = false;
    public bool rightCollider = false;
    public bool goDownCollider = false;
    public bool goUpCollider = false;
    public bool isBackCollider = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "colliderMovement")
        {
            forwardCollider = other.GetComponent<wagonRailway>().goForward;
            leftCollider = other.GetComponent<wagonRailway>().goLeft;
            rightCollider = other.GetComponent<wagonRailway>().goRight;
            goDownCollider = other.GetComponent<wagonRailway>().goDown;
            goUpCollider = other.GetComponent<wagonRailway>().goUp;
            isBackCollider = other.GetComponent<wagonRailway>().isBackCollider;

            // Si tengo una subida o una bajada
            if (goDownCollider)
            {
                giro = Quaternion.Euler(transform.rotation.eulerAngles.x - 25 * Mathf.Sign(speedForward), transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
            }
            else if (goUpCollider)
            {
                giro = Quaternion.Euler(transform.rotation.eulerAngles.x + 25 * Mathf.Sign(speedForward), transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
            }

            else if ((speedForward < 0 && isBackCollider) || (speedForward > 0 && !isBackCollider))
            {
                // Si no tengo un camino recto y no he decidido ningún camino
                if (!goLeft && !goRight && !forwardCollider)
                {
                    if (!leftCollider)
                    {
                        giro = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 90 * Mathf.Sign(speedForward), transform.rotation.eulerAngles.z);
                    }
                    else
                    {
                        giro = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y - 90 * Mathf.Sign(speedForward), transform.rotation.eulerAngles.z);
                    }
                }

                // Si no tengo camino a la derecha y lo tengo seleccionado
                else if (goRight && !rightCollider)
                {
                    if (!forwardCollider)
                    {
                        giro = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y - 90 * Mathf.Sign(speedForward), transform.rotation.eulerAngles.z);
                    }
                }

                // Si no tengo camino a la izquierda y lo tengo seleccionado
                else if (goLeft && !leftCollider)
                {
                    if (!forwardCollider)
                    {
                        giro = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 90 * Mathf.Sign(speedForward), transform.rotation.eulerAngles.z);
                    }
                }

                // Si tengo que realizar el giro normal horizontal
                else
                {
                    if (goRight == true)
                        giro = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 90 * Mathf.Sign(speedForward), transform.rotation.eulerAngles.z);

                    if (goLeft == true)
                        giro = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y - 90 * Mathf.Sign(speedForward), transform.rotation.eulerAngles.z);

                }
            }

            //preGiro = transform.rotation;
        }


        /*
        // Detecta la colision para curvas y cambios de pendiente
        if (other.gameObject.tag == "giroDerecho")
        {
            if (goRight == true && speedForward > 0)
                giro = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 90, transform.rotation.eulerAngles.z);
        }
        else if (other.gameObject.tag == "giroIzquierdo")
        {
            if (goLeft == true && speedForward > 0)
                giro = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y - 90, transform.rotation.eulerAngles.z);
        }
        else if (other.gameObject.tag == "giroDerechaContrario")
        {
            if (goLeft == true && speedForward < 0)
                giro = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y - 90, transform.rotation.eulerAngles.z);
        }
        else if (other.gameObject.tag == "giroIzquierdaContrario")
        {
            if (goLeft == true && speedForward < 0)
                giro = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 90, transform.rotation.eulerAngles.z);
        }
        else if (other.gameObject.tag == "subida")
        {
            giro = Quaternion.Euler(transform.rotation.eulerAngles.x + 25 * Mathf.Sign(speedForward), transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        }
        else if (other.gameObject.tag == "bajada")
        {
            giro = Quaternion.Euler(transform.rotation.eulerAngles.x - 25 * Mathf.Sign(speedForward), transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        }*/
    }

    void Start()
    {
        giro = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            /*if (speedForward == -1)
            {
                // Esto quiere decir que estoy girando
                if (giro.eulerAngles.y % 360 != transform.rotation.eulerAngles.y % 360)
                {
                    giro = Quaternion.Euler(preGiro.eulerAngles.x, preGiro.eulerAngles.y - transform.rotation.eulerAngles.y, preGiro.eulerAngles.z);
                }
            }*/
            if (transform.rotation.eulerAngles.y % 360 == giro.eulerAngles.y % 360)
            {
                speedForward += 1;
                if (speedForward > 3) speedForward = 3;
            }  
            /*if (transform.rotation.eulerAngles.y % 360 == giro.eulerAngles.y % 360 && speedForward == 0)
            {
                speedForward = -1;
            }*/
        }

        if (Input.GetKeyDown("s"))
        {
            /*if (speedForward == 1)
            {
                if (giro.eulerAngles.y % 360 != transform.rotation.eulerAngles.y % 360)
                {
                    giro = Quaternion.Euler(preGiro.eulerAngles.x, preGiro.eulerAngles.y - transform.rotation.eulerAngles.y, preGiro.eulerAngles.z);
                }
            }*/
            if (transform.rotation.eulerAngles.y % 360 == giro.eulerAngles.y % 360)
            {
                speedForward -= 1;
                if (speedForward < -2) speedForward = -2;
            }
            /*if (transform.rotation.eulerAngles.y % 360 == giro.eulerAngles.y % 360 && speedForward == 0)
            {
                speedForward = 1;
            }*/
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

        // Movimiento en la dirección Z de la vagoneta
        transform.Translate(Vector3.forward * Time.deltaTime * speedForward);
        if (speedForward != 0)
            transform.rotation = Quaternion.RotateTowards(transform.rotation, giro, 10 * Time.deltaTime * Mathf.Abs(speedForward));
    }
}
