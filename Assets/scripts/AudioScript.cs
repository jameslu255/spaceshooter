using UnityEngine;
using System.Collections;

public class AudioScript : MonoBehaviour
{

    public AudioClip MusicClip;
    public AudioSource MusicSource;

    // Use this for initialization
    void Start()
    {
        MusicSource.clip = MusicClip;
    }

    // Update is called once per frame
    void Update()
    {
        if (MultiShooter.fired == true)
		{
            MusicSource.Play();
            MultiShooter.fired = false;
		}
    }
}

