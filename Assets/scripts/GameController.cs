using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject Droid;
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
        StartNewGame();
    }


    private void StartNewGame()
    {
        score = 0;
        MusicSource.clip = MusicClip;
        MusicSource.Play();
        StartCoroutine(SpawnWaves());
        StartCoroutine(SpawnDroids());
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

    IEnumerator SpawnDroids()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < 3; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, Random.Range(spawnValues.z, spawnValues.z * 5));
                Quaternion spawnRotation = Quaternion.Euler(new Vector3(270, 0, 0));
                var droid = Instantiate(Droid, spawnPosition, spawnRotation);
                droid.GetComponent<DroidController>().RemoveAllMovementTypes();
                droid.AddComponent<RandomBurstMovement>();
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            StartNewGame();
        }
    }
}
