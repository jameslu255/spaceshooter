using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private AudioClip MusicClip;
    [SerializeField] private AudioSource MusicSource;
    [SerializeField] private GameObject explosion;
    [SerializeField] private GameObject playerExplosion;
    [SerializeField] private float Speed;
    [SerializeField] private float RotationAngle = 30f;
    private Rigidbody Rb;
    private BoxCollider PlayerBoundary;

    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        MusicSource.clip = MusicClip;
        PlayerBoundary = GameObject.Find("PlayerBoundary").GetComponent<BoxCollider>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Rb.MoveRotation(Quaternion.Euler(new Vector3(90, 0, -1 * RotationAngle * moveHorizontal)));
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        Rb.AddForce(movement * Speed, ForceMode.Impulse);
        CheckPlayerBoundary();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerBoundary")
        {
            Rb.velocity = Vector3.zero;
            Debug.Log(Time.deltaTime);
            return;
        }
        if (other.tag == "Enemy")
        {
            MusicSource.Play();
            Instantiate(playerExplosion, transform.position, transform.rotation);
            Instantiate(explosion, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    private void CheckPlayerBoundary()
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
        }
        if (z > boundaryZ + zOffset || z < zOffset - boundaryZ)
        {
            z = ((z < zOffset) ? -1 : 1) * boundaryZ + zOffset;
        }

        Rb.position = new Vector3(x, y, z);
    }
}
