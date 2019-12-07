using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovement : MovementBase
{
    [SerializeField] private float Amplitude;

    protected override void Move()
    {
        var newPosition = new Vector3();
        newPosition.x = Rb.position.x + Amplitude * Time.deltaTime * DirectionX;
        newPosition.y = Rb.position.y;
        newPosition.z = Rb.position.z;
        Rb.position = newPosition;
        CheckBoundary();
    }

    protected override void RandomizeParameters()
    {
        Amplitude = Random.Range(5f, 15f);
    }
}
