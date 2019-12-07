using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralMovement : MovementBase
{
    [SerializeField] private float RotationalSpeed;
    [SerializeField] private float Radius;
    [SerializeField] private float Angle;

    protected override void Move()
    {
        Angle += RotationalSpeed * Time.deltaTime;
        var offset = new Vector3(Mathf.Sin(Angle), 0, Mathf.Cos(Angle)) * Radius * Time.deltaTime;
        Rb.position = Rb.position + offset;
        CheckBoundary();
    }

    protected override void RandomizeParameters()
    {
        int[] tempArray = { -1, 1 };
        Angle = Random.Range(0f, 360f);
        Radius = Random.Range(18f, 30f);
        RotationalSpeed = Random.Range(2f, 5f) * tempArray[Random.Range(0, 2)];
    }
}
