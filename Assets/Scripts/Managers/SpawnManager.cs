using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using Random = System.Random;
// .!.
public class SpawnManager : MonoBehaviour
{
    //Debug
    [SerializeField] private bool debug = false;
    
    //Admin
    private Administrator _administrator;
    
    //Enumerators
    private IEnumerator _spawnerEnumerator;
    
    //Objects
    [SerializeField] private GameObject spawnPrefab;
    [SerializeField] private GameObject[] spawnObjects;

    //Spawn limiters
    public int spawnTargetLimit = 20;   // Spawn total enemies in this wave
    public int spawnCount = 0;          // Spawned enemies right now
    public int spawnSceneLimit = 10;    // Can be spawned in this wave simultaneously
    
    //Kill count for wave stop
    public int killCount = 0;
    

    //Spawn time things
    private const float SpawnTimer = 1.0f;
    private const float SpawnDelay = 3.0f;

    private void Awake()
    {
        _spawnerEnumerator = SpawnerWithTimer();
        
        _administrator = GetComponentInParent<Administrator>();
    }
    
    public void Start()
    {
        spawnTargetLimit = _administrator.GetEnemyAmount();
        _administrator.SetTarget(spawnTargetLimit);
            
        if (debug) {Debug.Log("SpawnManager: Start. Enemy amount: " + spawnTargetLimit);}
        
        StartCoroutine(_spawnerEnumerator);
    }
    
    IEnumerator SpawnerWithTimer()
    {
        if (debug) {Debug.Log("SpawnManager: Wave began. Timer: " + SpawnTimer);}
        yield return new WaitForSeconds(SpawnDelay);

        while (true)
        {
            if (killCount >= spawnTargetLimit)
            {
                while (spawnCount != 0)
                {
                    yield return new WaitForSeconds(SpawnTimer);
                }
                
                Debug.Log("SpawnManager: Wave restarting began");
                ChangeWave(1);
            }

            if (spawnTargetLimit >= spawnSceneLimit)
            {
                yield return new WaitForSeconds(SpawnTimer);
            }
            
            spawnCount++;
            SpawnEnemy();
            
            yield return new WaitForSeconds(SpawnTimer);
        }
    }
    
    private void SpawnEnemy()
    {
        //Random spawn zone
        int zoneNumber = UnityEngine.Random.Range(0, spawnObjects.Length);
        
        //Random point in spawn zone
        float randomX = UnityEngine.Random.Range(0, spawnObjects[zoneNumber].gameObject.transform.localScale.x);
        float randomY = UnityEngine.Random.Range(0, spawnObjects[zoneNumber].gameObject.transform.localScale.y);
        
        //Vector 3 with random coordinates
        Vector3 spawnPos = new Vector3(
            randomX - spawnObjects[zoneNumber].gameObject.transform.localScale.x / 2, 
            randomY - spawnObjects[zoneNumber].gameObject.transform.localScale.y / 2, 
            1) 
                           + spawnObjects[zoneNumber].transform.position;
        
        //Creating enemy
        Instantiate(spawnPrefab, spawnPos, Quaternion.identity, this.transform);

        //Debug
        if (debug)
        {
            Debug.Log("SpawnManager: Spawned " + spawnPrefab.name + " at location " + spawnPos);
        }
    }

    private void ChangeWave(int waveChanger)
    {
        StopCoroutine(_spawnerEnumerator);
        _administrator.ChangeWave(waveChanger);
        _administrator.SetTarget(spawnTargetLimit);
        spawnTargetLimit = _administrator.GetEnemyAmount();
        killCount = 0;
        
        _spawnerEnumerator = SpawnerWithTimer();
        StartCoroutine(_spawnerEnumerator);
    }
    
    public void AddScore(int scoreToAdd)
    {
        _administrator.AddScore(scoreToAdd);
    }
}
