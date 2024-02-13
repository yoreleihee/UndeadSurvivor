using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabs;
    private List<GameObject>[] _pools;

    private void Awake()
    {
        _pools = new List<GameObject>[prefabs.Length];

        for (int i = 0; i < _pools.Length; i++)
        {
            _pools[i] = new List<GameObject>();
        }
    }

    public GameObject Get(int index)
    {
        GameObject select = null;

        foreach (var item in _pools[index])
        {
            if (!item.activeSelf)
            {
                select = item;
                select.SetActive(true);

                return select;
            }
        }
        
        // pool에 남은 프리팹이 없는 경우 새로 생성
        select = Instantiate(prefabs[index], transform);
        _pools[index].Add(select);
        return select;
    }
}
