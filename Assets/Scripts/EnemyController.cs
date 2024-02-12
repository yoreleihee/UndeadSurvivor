using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject target;
    
    [Header("Enemy Data")]
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rigid;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        var position = transform.position;
        
        var dir = target.transform.position - position;
        var nextMoveVec = dir * (speed * Time.fixedDeltaTime);
        rigid.MovePosition(position + nextMoveVec);
        rigid.velocity = Vector3.zero;
    }

    private void LateUpdate()
    {
        spriteRenderer.flipX = target.transform.position.x < transform.position.x;
    }
}
