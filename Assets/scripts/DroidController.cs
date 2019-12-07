using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroidController : MonoBehaviour
{
    [SerializeField] private float Speed;
    private BoxCollider PlayerBoundary;
    private GameObject Player; 
    private Rigidbody Rb;

    // Circular movement.
    private float RotationalSpeed = 3f;
    private float Radius = 25f;
    private float Angle;

    // Linear movement.
    private float Amplitude = 10f;
    private int DirectionX = -1;
    private int DirectionZ = -1;


    private void Start()
    {
        Player = GameObject.Find("Player");
        PlayerBoundary = GameObject.Find("PlayerBoundary").GetComponent<BoxCollider>();
        Rb = GetComponent<Rigidbody>();
        IgnorePlayerBoundaryCollider();
        Rb.velocity = transform.forward * Speed;

        // Randomize parameters for circular movement.
        int[] tempArray = { -1, 1 };
        Angle = Random.Range(0f, 360f);
        RotationalSpeed = Random.Range(2f, 5f) * tempArray[Random.Range(0, 2)];

        // Randomize parameters for linear movement.
        Amplitude = Random.Range(5f, 15f);

        this.gameObject.AddComponent<ZigZagMovement>();
    }

    private void IgnorePlayerBoundaryCollider()
    {
        var playerBoundaryCollider = GameObject.Find("PlayerBoundary").GetComponent<BoxCollider>();
        var asteroidCollider = GetComponent<CapsuleCollider>();
        Physics.IgnoreCollision(playerBoundaryCollider, asteroidCollider);
    }

    private void ZigZagMovement()
    {
        var newPosition = new Vector3();
        newPosition.x = Rb.position.x + Amplitude * Time.deltaTime * DirectionX;
        newPosition.z = Rb.position.z + Amplitude * Time.deltaTime * DirectionZ;
        newPosition.y = Rb.position.y;
        Rb.position = newPosition;
        CheckBoundary();
    }

    private void CheckBoundary()
    {
        var boundaryX = PlayerBoundary.size.x / 2;
        var boundaryZ = PlayerBoundary.size.z / 2;
        var zOffset = 27f;
        var x = Rb.position.x;
        var y = Rb.position.y;
        var z = Rb.position.z;

        if (Mathf.Abs(x) > boundaryX)
        {
            x = ((x < 0) ? -1 : 1) * boundaryX;
            DirectionX *= -1;
        }
        if (z > boundaryZ + zOffset || z < zOffset - boundaryZ)
        {
            z = ((z < zOffset) ? -1 : 1) * boundaryZ + zOffset;
            DirectionZ *= -1;
        }

        Rb.position = new Vector3(x, y, z);
    }
}
