using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovement : MovementBase
{
    [SerializeField] private float Amplitude;

    protected override void Move()
    {
        var newPosition = new Vector3();
        newPosition.z = Rb.position.z + Amplitude * Time.deltaTime * DirectionZ;
        newPosition.y = Rb.position.y;
        newPosition.x = Rb.position.x;
        Rb.position = newPosition;
        CheckBoundary();
    }

    protected override void RandomizeParameters()
    {
        Amplitude = Random.Range(5f, 15f);
    }
}
