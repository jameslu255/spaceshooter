using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBurstMovement : MovementBase
{
    [SerializeField] private float BurstSpeed;
    [SerializeField] private float BurstDelay;
    [SerializeField] private float BurstTime = 4f;
    private float ElapsedTime;
    private float ElapsedBurstTime;

    protected override void Move()
    {
        var newPosition = new Vector3
        {
            x = Rb.position.x + Random.Range(9f, 15f) * Time.deltaTime * DirectionX,
            z = Rb.position.z + Random.Range(9f, 15f) * Time.deltaTime * DirectionZ,
            y = Rb.position.y
        };
        Rb.position = newPosition;
        CheckBoundary();
    }

    protected new void FixedUpdate()
    {
        Move();

        if (ElapsedBurstTime < BurstTime)
        {
            ElapsedBurstTime += Time.deltaTime;
            Speed = BurstSpeed;
        }
        else
        {
            ElapsedTime += Time.deltaTime;
            if (ElapsedTime > BurstDelay)
            {
                ElapsedTime = 0;
                ElapsedBurstTime = 0;
            }
            Speed = 9f;
        }
        Rb.velocity = transform.forward * Speed;
    }

    protected override void RandomizeParameters()
    {
        BurstTime = Random.Range(0.5f, 1.2f);
        BurstDelay = Random.Range(0.5f, 3f);
        BurstSpeed = Random.Range(40f, 80f);
    }
}
