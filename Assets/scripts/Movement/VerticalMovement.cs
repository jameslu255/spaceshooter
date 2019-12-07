using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovement : MovementBase
{
    [SerializeField] private float Amplitude;

    protected override void Move()
    {
        if (!Rb)
        {
            return;
        }
        var newPosition = new Vector3
        {
            z = Rb.position.z + Amplitude * Time.deltaTime * DirectionZ,
            y = Rb.position.y,
            x = Rb.position.x
        };
        Rb.position = newPosition;
        CheckBoundary();
    }

    protected override void RandomizeParameters()
    {
        Amplitude = Random.Range(5f, 15f);
    }
}
