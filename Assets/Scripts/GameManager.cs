using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public PlayerController player;
    public PoolManager poolManager;
    public float gameTime;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        gameTime += Time.deltaTime;
    }
}
