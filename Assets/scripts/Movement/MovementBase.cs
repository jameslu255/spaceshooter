using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementBase : MonoBehaviour
{
    [SerializeField] protected float Speed;
    protected BoxCollider PlayerBoundary;
    protected Rigidbody PlayerRb;
    protected Rigidbody Rb;
    protected int DirectionX = -1;
    protected int DirectionZ = -1;
    protected readonly float OffsetZ = 27f;

    protected abstract void RandomizeParameters();
    protected abstract void Move();

    protected void Start()
    {
        var Player = GameObject.Find("Player");
        if (Player)
        {
            PlayerRb = Player.GetComponent<Rigidbody>();
        }
        else
        {
            PlayerRb = null;
        }

        PlayerBoundary = GameObject.Find("PlayerBoundary").GetComponent<BoxCollider>();
        Rb = GetComponent<Rigidbody>();
        InitVelocity();
        RandomizeParameters();
    }

    protected virtual void InitVelocity()
    {
        Speed = 9f;
        Rb.velocity = transform.forward * Speed;
    }

    protected void FixedUpdate()
    {
        Move();
    }

    protected void CheckBoundary()
    {
        var boundaryX = PlayerBoundary.size.x / 2;
        var boundaryZ = PlayerBoundary.size.z / 2;
        var x = Rb.position.x;
        var y = Rb.position.y;
        var z = Rb.position.z;

        if (Mathf.Abs(x) > boundaryX)
        {
            x = ((x < 0) ? -1 : 1) * boundaryX;
            DirectionX *= -1;
        }
        if (z > boundaryZ + OffsetZ || z < OffsetZ - boundaryZ)
        {
            z = ((z < OffsetZ) ? -1 : 1) * boundaryZ + OffsetZ;
            DirectionZ *= -1;
        }

        Rb.position = new Vector3(x, y, z);
    }
}
