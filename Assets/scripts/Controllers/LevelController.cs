using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private GameObject Droid;
    [SerializeField] private GameObject Asteroid;

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
            for (int i = 0; i < AsteroidCount; i++)
            {
                var spawnPosition = GenerateRandomSpawnPosition();
                var asteroid = Instantiate(Asteroid, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(UnitSpawnDelay);
            }
            yield return new WaitForSeconds(WaveDelay);
        }
    }

    IEnumerator StartDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }

    IEnumerator SpawnDroids()
    {
        for (int wave = 0; wave < WaveCount; wave++)
        {
            for (int i = 0; i < DroidCount; i++)
            {
                var spawnPosition = GenerateRandomSpawnPosition();
                var spawnRotation = Quaternion.Euler(new Vector3(270, 0, 0));
                var droid = Instantiate(Droid, spawnPosition, spawnRotation);
                droid.GetComponent<DroidController>().AddRandomMovement();
                yield return new WaitForSeconds(UnitSpawnDelay);
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
                var cornerDroid = Instantiate(Droid);
                cornerDroid.AddComponent<CornerMovement>();
                yield return new WaitForSeconds(UnitSpawnDelay);
            }
            yield return new WaitForSeconds(WaveDelay);
        }
    }

    private Vector3 GenerateRandomSpawnPosition()
    {
        var boundary = GameObject.Find("AsteroidBoundary").GetComponent<BoxCollider>();
        var padding = 5f;
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
        WaveCount = 8;
        DroidCount = 3;
    }
}
