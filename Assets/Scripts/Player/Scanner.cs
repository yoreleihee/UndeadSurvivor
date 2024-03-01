using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    [SerializeField] private float scanRange;
    [SerializeField] private LayerMask targetLayer;
    private RaycastHit2D[] _targets;
    [SerializeField] private Transform _nearestTarget;

    private void FixedUpdate()
    {
        _targets = Physics2D.CircleCastAll(transform.position, scanRange, Vector3.zero, 0, targetLayer);

        if (_targets.Length > 0)
        {
            _nearestTarget = GetNearestTarget(_targets);    
        }
    }
    
    void OnDrawGizmos()
    {
        // 기즈모 색상 설정
        Gizmos.color = Color.green;

        // 원형 기즈모 그리기
        Gizmos.DrawWireSphere(transform.position, scanRange);
    }

    private Transform GetNearestTarget(RaycastHit2D[] targets)
    {
        // initialize
        var result = targets[0].transform;
        
        var diff = 100f;
        foreach (var target in targets)
        {
            var myPos = transform.position;
            var targetPos = target.transform.position;
            var currDiff = Vector3.Distance(myPos, targetPos);

            if (currDiff < diff)
            {
                diff = currDiff;
                result = target.transform;
            }
        }

        return result;
    }
}
