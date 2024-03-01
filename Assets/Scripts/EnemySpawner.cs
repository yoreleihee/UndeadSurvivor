using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoint;
    [SerializeField] private int level;
    [SerializeField] private float levelInterval = 10;

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
        // Todo : level은 DataManager.Enemies.length만큼만 증가해야 한다.
        level = Mathf.Min(Mathf.FloorToInt(GameManager.Instance.gameTime / levelInterval), DataManager.Enemies.Count -1);
    }

    private async UniTaskVoid SpawnTimer()
    {
        while (true)
        {
            Spawn();
            await UniTask.Delay(TimeSpan.FromSeconds(DataManager.Enemies[level].SpawnTime));
        }
    }
    
    private void Spawn()
    {
        var enemy = GameManager.Instance.poolManager.Get(0);
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
        
        enemy.GetComponent<EnemyController>().Init(DataManager.Enemies[level]);
    }
}

