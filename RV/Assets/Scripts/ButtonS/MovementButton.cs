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
            vagoneta.PressLeft();
        else if (dir == direccion.Right)
            vagoneta.PressRight();
    }
}
