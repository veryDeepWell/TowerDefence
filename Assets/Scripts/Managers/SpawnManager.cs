using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using Random = System.Random;
// .!.
public class SpawnManager : MonoBehaviour
{
    //Debug
    [SerializeField] private bool DEBUG = false;
    
    //Admin
    private Administrator administrator;
    
    //Enumerators
    private IEnumerator _spawnerEnumerator;
    
    //Objects
    [SerializeField] private GameObject spawnPrefab;
    [SerializeField] private GameObject[] spawnObjects;
    
    //Gizmo shit
    private readonly int width;
    private readonly int height;

    //Spawn limiters
    public int spawnTargetLimit = 20;   // Spawn total enemies in this wave
    public int spawnCount = 0;          // Spawned enemies right now
    public int spawnSceneLimit = 10;    // Can be spawned in this wave simultaneously
    
    //Kill count for wave stop
    public int killCount = 0;
    

    //Spawn time things
    private const float _spawnTimer = 1.0f;
    private const float _spawnDelay = 3.0f;

    private void Awake()
    {
        _spawnerEnumerator = SpawnerWithTimer();
        
        administrator = GetComponentInParent<Administrator>();
    }
    
    public void Start()
    {
        spawnTargetLimit = administrator.GetEnemyAmount();
            
        if (DEBUG) {Debug.Log("SpawnManager: Start. Enemy amount: " + spawnTargetLimit);}
        
        StartCoroutine(_spawnerEnumerator);
    }
    
    IEnumerator SpawnerWithTimer()
    {
        if (DEBUG) {Debug.Log("SpawnManager: Wave began. Timer: " + _spawnTimer);}
        yield return new WaitForSeconds(_spawnDelay);

        while (true)
        {
            if (killCount >= spawnTargetLimit)
            {
                while (spawnCount != 0)
                {
                    yield return new WaitForSeconds(_spawnTimer);
                }
                
                Debug.Log("SpawnManager: Wave restarting began");
                ChangeWave(1);
            }

            if (spawnTargetLimit >= spawnSceneLimit)
            {
                yield return new WaitForSeconds(_spawnTimer);
            }
            
            spawnCount++;
            SpawnEnemy();
            
            yield return new WaitForSeconds(_spawnTimer);
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
        if (DEBUG)
        {
            Debug.Log("SpawnManager: Spawned " + spawnPrefab.name + " at location " + spawnPos);
        }
    }

    private void ChangeWave(int waveChanger)
    {
        StopCoroutine(_spawnerEnumerator);
        administrator.ChangeWave(waveChanger);
        spawnTargetLimit = administrator.GetEnemyAmount();
        killCount = 0;
        
        _spawnerEnumerator = SpawnerWithTimer();
        StartCoroutine(_spawnerEnumerator);
    }
    
    public void AddScore(int scoreToAdd)
    {
        administrator.AddScore(scoreToAdd);
    }
    
    private void OnDrawGizmos()
    {
        if (!DEBUG) return;
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(this.transform.position, new Vector3(width, height, 0));
    }
}
