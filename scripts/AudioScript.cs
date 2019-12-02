using UnityEngine;
using System.Collections;

public class AudioScript : MonoBehaviour {

	public AudioClip MusicClip;
	public AudioSource MusicSource;
    public float fireRate = 0.5F;
    private float nextFire = 0.0F;

    // Use this for initialization
    void Start () {
		MusicSource.clip = MusicClip;

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
		{
            nextFire = Time.time + fireRate;
            MusicSource.Play();
		}

	}
}
