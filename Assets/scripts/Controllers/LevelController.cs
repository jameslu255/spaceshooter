using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] private GameObject Droid;
    [SerializeField] private GameObject Asteroid;
    [SerializeField] private GameObject LaserPowerUp;

    private int Level;
    private int WaveCount;
    private int DroidCount;
    private int AsteroidCount;
    private float WaveDelay;
    private float UnitSpawnDelay;
    private float LevelStartDelay;

    public void StartLevel()
    {
        StartCoroutine(StartDelay(LevelStartDelay));
        StartCoroutine(SpawnCornerDroids());
        StartCoroutine(SpawnAsteroids());
        StartCoroutine(SpawnDroids());
    }

    IEnumerator SpawnAsteroids()
    {
        for (int wave = 0; wave < WaveCount; wave++)
        {
            if (wave == 6)
            {
                var spawnPosition = GenerateRandomSpawnPosition();
                Instantiate(LaserPowerUp, spawnPosition, Quaternion.identity);
            }
            if (wave == 8)
            {
                DroidCount = 10;
                AsteroidCount = 50;
            }
            for (int i = 0; i < AsteroidCount; i++)
            {
                var spawnPosition = GenerateRandomSpawnPosition();
                Instantiate(Asteroid, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(UnitSpawnDelay);
            }
            yield return new WaitForSeconds(WaveDelay);
        }
        StartCoroutine(StartDelay(3f));
        Initiate.Fade("Victory", Color.white, 0.4f);
    }

    public IEnumerator StartDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }

    IEnumerator SpawnDroids()
    {
        for (int wave = 0; wave < WaveCount; wave++)
        {
            for (int i = 0; i < DroidCount; i++)
            {
                if (wave > 4)
                {
                    var spawnPosition = GenerateRandomSpawnPosition();
                    var spawnRotation = Quaternion.Euler(new Vector3(270, 0, 0));
                    var droid = Instantiate(Droid, spawnPosition, spawnRotation);
                    droid.GetComponent<DroidController>().AddRandomMovement();
                    yield return new WaitForSeconds(UnitSpawnDelay);
                }

            }

            yield return new WaitForSeconds(WaveDelay);
        }
    }

    IEnumerator SpawnCornerDroids()
    {
        for (int wave = 0; wave < WaveCount; wave++)
        {
            for (int i = 0; i < DroidCount; i++)
            {
                if (wave > 4)
                {
                    var cornerDroid = Instantiate(Droid);
                    cornerDroid.AddComponent<CornerMovement>();
                    yield return new WaitForSeconds(UnitSpawnDelay);
                }

            }

            yield return new WaitForSeconds(WaveDelay);
        }
    }

    private Vector3 GenerateRandomSpawnPosition()
    {
        var boundary = GameObject.Find("AsteroidBoundary").GetComponent<BoxCollider>();
        var padding = 1f;
        var zOffset = 30f;
        var boundaryX = boundary.size.x / 2 - padding;
        var boundaryY = boundary.size.y / 2 - padding;
        var boundaryZ = boundary.size.z / 2 - padding;

        return new Vector3()
        {
            x = Random.Range(-boundaryX, boundaryX),
            y = boundaryY * -1,
            z = Random.Range(zOffset - boundaryZ, zOffset + boundaryZ)
        };
    }

    public int GetLevel()
    {
        return Level;
    }

    public void SetLevel(int newLevel)
    {
        Level = newLevel;
        // TODO: Change parameters based on the level here.
        AsteroidCount = 30;
        UnitSpawnDelay = 0.05f;
        LevelStartDelay = 1f;
        WaveDelay = 4f;
        WaveCount = 14;
        DroidCount = 3;
    }
}
