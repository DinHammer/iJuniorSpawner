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

    // Start is called before the first frame update
    void Start()
    {
        int delayTime = 0;
        Vector3 position = Vector3.zero;
        
        for (int i = 0; i < _childCount; i++)
        {
            delayTime += _spawnDelayInSecond;
            position = _spawnPoints[i].Position;

            StartCoroutine(SpawnEnemy(delayTime, position));
        }
        
    }

    private IEnumerator SpawnEnemy(int delaySecond, Vector3 position)
    {
        yield return new WaitForSeconds(delaySecond);
        _enemy.Spawn(position);   
    }
}
