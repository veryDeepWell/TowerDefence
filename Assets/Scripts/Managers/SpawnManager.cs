using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using Random = System.Random;

public class SpawnManager : MonoBehaviour
{
    //Debug
    [SerializeField] private bool DEBUG = false;
    
    //Admin
    private Administrator administrator;
    
    //Objects
    [SerializeField] private GameObject spawnPrefab;
    [SerializeField] private GameObject[] spawnObjects;
    
    //Gizmo
    private readonly int width;
    private readonly int height;

    //Spawn limiters
    public int spawnTargetLimit = 20;
    public int spawnCount = 0;
    public int spawnSceneLimit = 10;
    
    //Kill count for wave stop
    private int killCount = 0;
    
    //Spawn time things
    private const float _spawnTimer = 1.0f;
    private const float _spawnDelay = 3.0f;

    private void Awake()
    {
        administrator = GetComponentInParent<Administrator>();
    }
    
    public void Start()
    {
        spawnTargetLimit = administrator.GetEnemyAmount();
            
        if (DEBUG) {Debug.Log("SpawnManager: Start. Enemy amount: " + spawnTargetLimit);}
        
        StartCoroutine(SpawnerWithTimer());
    }

    private void OnDrawGizmos()
    {
        if (!DEBUG) return;
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(this.transform.position, new Vector3(width, height, 0));
    }

    // ReSharper disable Unity.PerformanceAnalysis
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
            Debug.Log("Spawned " + spawnPrefab.name + " at location " + spawnPos);
        }
    }
    
    IEnumerator SpawnerWithTimer()
    {
        yield return new WaitForSeconds(_spawnDelay);
        
        while (true)
        {
            if (spawnCount < spawnSceneLimit)
            {
                SpawnEnemy();
                spawnCount = spawnCount + 1;
            }

            yield return new WaitForSeconds(_spawnTimer);
        }
    }

    public void AddScore(int scoreToAdd)
    {
        administrator.AddScore(scoreToAdd);
    }
}
