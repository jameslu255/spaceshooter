 using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DestroyByContact : MonoBehaviour {

    public AudioClip MusicClip;
    public AudioSource MusicSource;

    public GameObject explosion;
    public GameObject playerExplosion;

    void OnTriggerEnter(Collider other)
    {
        MusicSource.clip = MusicClip;
        if (other.tag == "Boundary")
        {
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
}
