using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementButton : ButtonScript
{

    public followPath vagoneta;
    public direccion dir;

    public enum direccion
    {
        Forward,
        Backwards,
        Left,
        Right
    }

    public override void ActiveAction()
    {
        if (dir == direccion.Forward)
            vagoneta.PressForward();
        else if (dir == direccion.Backwards)
            vagoneta.PressBackward();
        else if (dir == direccion.Left)
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(0.35f, 0, 0.5f);
            vagoneta.goLeft = true;
        }
        else if (dir == direccion.Right)
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(0.35f, 0, 0.5f);
            vagoneta.goRight = true;
        }
    }

    public override void InactiveAction()
    {
        if (dir == direccion.Left)
        {
            vagoneta.goLeft = false;
        }
        else if (dir == direccion.Right)
        {
            vagoneta.goRight = false;
        }

        gameObject.GetComponent<Renderer>().material.color = new Color(0.96f, 0.26f, 0.21f);

    }
}
