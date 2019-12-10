using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public AudioClip MusicClip;
    public AudioSource MusicSource;

    public static int Score;

    void Start()
    {
        StartNewGame();
    }

    private void StartNewGame()
    {
        Score = 0;
        MusicSource.clip = MusicClip;
        MusicSource.Play();
        GetComponent<LevelController>().SetLevel(1);
        GetComponent<LevelController>().StartLevel();
    }

    public void AddScore(int newScoreValue)
    {
        Score += newScoreValue;
    }

    public int returnScore()
    {
        return Score;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            StartNewGame();
        }
    }

    public void EndGame()
    {

    }
}
