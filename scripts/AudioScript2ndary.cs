using UnityEngine;
using System.Collections;

public class AudioScript2ndary : MonoBehaviour {

	public AudioClip MusicClip;
	public AudioSource MusicSource;

	// Use this for initialization
	void Start () {
		MusicSource.clip = MusicClip;

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(1))
		{
			MusicSource.Play();
		}

	}
}
