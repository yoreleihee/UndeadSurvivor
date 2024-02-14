using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoint;
    [SerializeField] private int level;
    [SerializeField] private float levelInterval = 10;
    [SerializeField] private float spawnIntervalEasyLevel = 3f;
    [SerializeField] private float spawnIntervalNormalLevels = 1f;


    private void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
    }

    private void Start()
    {
        SpawnTimer().Forget();
    }

    private void Update()
    {
        level = Mathf.FloorToInt(GameManager.Instance.gameTime / levelInterval);
    }

    private async UniTaskVoid SpawnTimer()
    {
        while (true)
        {
            Spawn();
            await UniTask.Delay(level == 0 ? TimeSpan.FromSeconds(spawnIntervalEasyLevel) : TimeSpan.FromSeconds(spawnIntervalNormalLevels));
        }
    }
    
    private void Spawn()
    {
        var enemy = GameManager.Instance.poolManager.Get(level);
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
    }
}
