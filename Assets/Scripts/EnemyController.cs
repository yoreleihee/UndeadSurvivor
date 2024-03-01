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
    [SerializeField] private float health;
    [SerializeField] private float maxHealth; 
    [SerializeField] private RuntimeAnimatorController[] animCon;
    [SerializeField] private bool isLive;
    
    [Header("Enemy Component")]
    [SerializeField] private Rigidbody2D rigid;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    public void Init(Enemy enemyData)
    {
        speed = enemyData.Speed;
        maxHealth = enemyData.Health;
        health = enemyData.Health;
        animator.runtimeAnimatorController = DataManager.LoadAnimator(enemyData.Animator);
    }

    private void FixedUpdate()
    {
        var position = transform.position;
        
        var dir = target.transform.position - position;
        var nextMoveVec = dir.normalized * (speed * Time.fixedDeltaTime);
        rigid.MovePosition(position + nextMoveVec);
        rigid.velocity = Vector3.zero; 
    }

    private void LateUpdate()
    {
        if (!isLive)
            return;
        
        spriteRenderer.flipX = target.transform.position.x < transform.position.x;
    }

    private void OnEnable()
    {
        target = GameManager.Instance.player.gameObject;
        isLive = true;
        health = maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var bullet = other.GetComponent<BulletController>();
        if (bullet != null)
        {
            // Todo : bullet.Init()
            health -= bullet.damage;
        }

        // Live
        if (health > 0)
        {
            // Todo : HitAction
        }

        else
        {
            Dead();
        }
    }

    private void Dead()
    {
        gameObject.SetActive(false);
    }
}
