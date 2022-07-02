using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Wave
{
    public string waveName;
    public int NumOfEnemies;
    public GameObject[] typeofEnemies;
    public float SpawnInterval;
}
public class WaveSpawner : MonoBehaviour
{
    public Wave[] waves;
    public Transform[] spwanPoint;

    private Wave currenWave;
    private int currentWaveNumber;

    private bool canSpwan = true;

    private void Update()
    {
        currenWave = waves[currentWaveNumber];
        SpawnWave();
    }
    void SpawnWave()
    {
        if (canSpwan) { 
        GameObject randomEnemy = currenWave.typeofEnemies[Random.Range(0, currenWave.typeofEnemies.Length)];
        Transform randomPoint = spwanPoint[Random.Range(0, spwanPoint.Length)];
        Instantiate(randomEnemy, randomPoint.position, Quaternion.identity);
            currenWave.NumOfEnemies--;
            if(currenWave.NumOfEnemies == 0)
            {
                canSpwan = false;
            }
        }
    }
}
