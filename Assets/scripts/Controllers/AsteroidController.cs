using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{

    [SerializeField] private float Speed;
    [SerializeField] private float RotationSpeed;

    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.up * Speed;
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * RotationSpeed;
        IgnorePlayerBoundaryCollider();
    }

    private void IgnorePlayerBoundaryCollider()
    {
        var playerBoundaryCollider = GameObject.Find("PlayerBoundary").GetComponent<BoxCollider>();
        //var asteroidBoundaryCollider = GameObject.Find("AsteroidBoundary").GetComponent<BoxCollider>();
        var asteroidCollider = GetComponent<CapsuleCollider>();
        Physics.IgnoreCollision(playerBoundaryCollider, asteroidCollider);
        //Physics.IgnoreCollision(asteroidBoundaryCollider, asteroidCollider);
    }

    void OnTriggerExit(Collider other)
    {
        //Debug.Log("COLLIDED!!");
        if (other.tag == "Boundary")
        {
            Destroy(this.gameObject);
        }
    }
}
