using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{

    [SerializeField] private float Speed;
    [SerializeField] private float RotSpeed;

    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.up * Speed;
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * RotSpeed;
        IgnorePlayerBoundaryCollider();
    }

    private void IgnorePlayerBoundaryCollider()
    {
        var playerBoundaryCollider = GameObject.Find("PlayerBoundary").GetComponent<BoxCollider>();
        var asteroidCollider = GetComponent<CapsuleCollider>();
        Physics.IgnoreCollision(playerBoundaryCollider, asteroidCollider);
    }
}
