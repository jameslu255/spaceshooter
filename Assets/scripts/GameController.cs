using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject Pirate;
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public AudioClip MusicClip;
    public AudioSource MusicSource;

    private int score;

    void Start()
    {
        score = 0;
        MusicSource.clip = MusicClip;
        MusicSource.Play();
        //StartCoroutine(SpawnWaves());
        StartCoroutine(SpawnPirates());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, Random.Range(spawnValues.z, spawnValues.z * 5));
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }

    IEnumerator SpawnPirates()
    {

        yield return new WaitForSeconds(startWait);
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < 3; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, Random.Range(spawnValues.z, spawnValues.z * 5));
                Quaternion spawnRotation = Quaternion.Euler(new Vector3(270, 0, 0));
                Instantiate(Pirate, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
    }

}
