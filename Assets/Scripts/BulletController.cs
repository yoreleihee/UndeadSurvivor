using System;
using UnityEngine;
using UnityEngine.U2D;

public class BulletController : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private string spriteName;
    private SpriteAtlas _spriteAtlas;
    public float damage { get; private set; }
    public float pierce { get; private set; }

    [Header("Component")] 
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        _spriteAtlas = DataManager.LoadAtlas("Bullets");
    }

    public void Init(Bullet bulletData)
    {
        spriteRenderer.sprite = _spriteAtlas.GetSprite(bulletData.SpriteName);
        damage = bulletData.Damage;
        pierce = bulletData.Pierce;
    }
}