using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using Random = System.Random;

public class SpawnManager : MonoBehaviour
{
    //Debug
    [SerializeField] private bool DEBUG = false;
    
    //Objects
    [SerializeField] private GameObject spawnPrefab;
    [SerializeField] private GameObject[] spawnObjects;
    
    [SerializeField] private int width;
    [SerializeField] private int height;

    //Spawn limiters
    private readonly int _spawnLimit = 10;
    public int spawnCount = 0;
    
    //Spawn time things
    private readonly float _spawnTimer = 1.0f;
    private readonly float _spawnDelay = 3.0f;

    public void Start()
    {
        StartCoroutine(SpawnerWithTimer());
    }

    private void OnDrawGizmos()
    {
        if (!DEBUG) return;
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(this.transform.position, new Vector3(width, height, 0));
    }

    public void SpawnEnemy()
    {
        int zoneNumber = UnityEngine.Random.Range(0, spawnObjects.Length);
        
        float randomX = UnityEngine.Random.Range(-10, 10);
        float randomY = UnityEngine.Random.Range(-10, 10);

        Vector3 spawnPos = new Vector3(randomX, randomY, 1);

        Instantiate(spawnPrefab, spawnPos, Quaternion.identity, this.transform);
    }
    
    IEnumerator SpawnerWithTimer()
    {
        yield return new WaitForSeconds(_spawnDelay);
        
        while (true)
        {
            if (spawnCount < _spawnLimit)
            {
                SpawnEnemy();
                spawnCount = spawnCount + 1;
            }

            yield return new WaitForSeconds(_spawnTimer);
        }
    }

    public void AddScore(int scoreToAdd)
    {
        Administrator administrator = GetComponentInParent<Administrator>();
        administrator.AddScore(scoreToAdd);
    }
}
