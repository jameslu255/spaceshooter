using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroidController : MonoBehaviour
{
    [SerializeField] private float Speed;
    private Rigidbody Rb;

    private void Start()
    {
        Rb = GetComponent<Rigidbody>();
        Rb.velocity = transform.forward * Speed;
        IgnorePlayerBoundaryCollider();
    }

    public void AddRandomMovement()
    {
        var random = Random.Range(0, 6);
        switch (random)
        {
            case 0:
                this.gameObject.AddComponent<HorizontalMovement>();
                break;
            case 1:
                this.gameObject.AddComponent<VerticalMovement>();
                break;
            case 2:
                this.gameObject.AddComponent<SpiralMovement>();
                break;
            case 3:
                this.gameObject.AddComponent<ZigZagMovement>();
                break;
            case 4:
                this.gameObject.AddComponent<BasicMovement>();
                break;
            case 5:
                this.gameObject.AddComponent<RandomBurstMovement>();
                break;
        }
    }

    public void RemoveAllMovementTypes()
    {
        var horizontal = this.gameObject.GetComponent<HorizontalMovement>();
        var vertical = this.gameObject.GetComponent<VerticalMovement>();
        var spiral = this.gameObject.GetComponent<SpiralMovement>();
        var zigzag = this.gameObject.GetComponent<ZigZagMovement>();

        if (horizontal)
        {
            Destroy(horizontal);
        }
        if (vertical)
        {
            Destroy(vertical);
        }
        if (spiral)
        {
            Destroy(spiral);
        }
        if (zigzag)
        {
            Destroy(zigzag);
        }
    }

    private void IgnorePlayerBoundaryCollider()
    {
        var playerBoundaryCollider = GameObject.Find("PlayerBoundary").GetComponent<BoxCollider>();
        var asteroidCollider = GetComponent<CapsuleCollider>();
        Physics.IgnoreCollision(playerBoundaryCollider, asteroidCollider);
    }
}
