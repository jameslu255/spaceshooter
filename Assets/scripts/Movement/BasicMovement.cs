using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MovementBase
{
    protected override void Move()
    {
        if (!Rb)
        {
            return;
        }
    }

    protected override void RandomizeParameters()
    {
    }
}
