using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZagMovement : MovementBase
{
    [SerializeField] private float AmplitudeX;
    [SerializeField] private float AmplitudeZ;

    protected override void Move()
    {
        var newPosition = new Vector3();
        newPosition.x = Rb.position.x + AmplitudeX * Time.deltaTime * DirectionX;
        newPosition.z = Rb.position.z + AmplitudeZ * Time.deltaTime * DirectionZ;
        newPosition.y = Rb.position.y;
        Rb.position = newPosition;
        CheckBoundary();
    }

    protected override void RandomizeParameters()
    {
        AmplitudeX = Random.Range(5f, 15f);
        AmplitudeZ = Random.Range(5f, 15f);
    }
}
