using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornerMovement : MovementBase
{
    private float X;
    private float Z;

    protected override void Move()
    {
        Rb.position = new Vector3(X, Rb.position.y, Z);
    }

    protected override void RandomizeParameters()
    {
        var rand = Random.Range(0, 4);
        Rb.velocity = Random.Range(20f, 40f) * transform.forward;
        switch (rand)
        {
            case 0:
                X = PlayerBoundary.size.x / 2;
                Z = OffsetZ + PlayerBoundary.size.z / 2;
                break;
            case 1:
                X = PlayerBoundary.size.x / -2;
                Z = OffsetZ + PlayerBoundary.size.z / 2;
                break;
            case 2:
                X = PlayerBoundary.size.x / 2;
                Z = OffsetZ - PlayerBoundary.size.z / 2;
                break;
            case 3:
                X = PlayerBoundary.size.x / -2;
                Z = OffsetZ - PlayerBoundary.size.z / 2;
                break;
        }
    }

}
