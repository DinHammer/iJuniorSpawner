using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private int _spawnDelayInSecond;
    
    private SpawnPoint[] _spawnPoints;
    private int _childCount;
    
    private void Awake()
    {
        _childCount = transform.childCount;
        _spawnPoints = new  SpawnPoint[_childCount];
        SpawnPoint spawnPoint = null;
        
        for (int i = 0; i < _childCount; i++)
        {
            spawnPoint = transform.GetChild(i).GetComponent<SpawnPoint>();
            _spawnPoints[i] = spawnPoint;
        }
    }
    
    private void Start()
    {
        StartCoroutine(SpawnEnemy(_spawnDelayInSecond, _spawnPoints, _enemy));
    }

    private IEnumerator SpawnEnemy(int delaySecond, SpawnPoint[] spawnPoints, Enemy enemy)
    {
        int count = spawnPoints.Length;

        for (int i = 0; i < count; i++)
        {
            yield return new WaitForSeconds(delaySecond);
            Instantiate(enemy, spawnPoints[i].Position, Quaternion.identity);
        }
    }
}
