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
        var droidCollider = GetComponent<CapsuleCollider>();
        Physics.IgnoreCollision(playerBoundaryCollider, droidCollider);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Boundary")
        {
            Destroy(this.gameObject);
        }
    }
}
