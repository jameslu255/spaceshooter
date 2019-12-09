using UnityEngine;
using System.Collections;

public class AudioScript2ndary : MonoBehaviour {

	public AudioClip MusicClip;
	public AudioSource MusicSource;

    public AudioClip MusicClip2;

    // Use this for initialization
    void Start () {
		MusicSource.clip = MusicClip;
	}

	// Update is called once per frame
	void Update () {
		if (MultiShooter.secondaryFired == true)
		{
            MusicSource.Play();
            MultiShooter.secondaryFired = false;
		}
	}
}

//testing commit from master