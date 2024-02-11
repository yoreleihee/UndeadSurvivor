using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Vector2 inputVec;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed;
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private Animator _animator;
    private static readonly int SPEED = Animator.StringToHash("Speed");

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Vector2 nextVec = inputVec.normalized * (_speed * Time.fixedDeltaTime);
        _rigidbody.MovePosition(_rigidbody.position + nextVec);
    }

    private void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }

    private void LateUpdate()
    {
        _animator.SetFloat(SPEED, inputVec.magnitude);
        if (inputVec.x != 0)
        {
            _sprite.flipX = inputVec.x < 0;
        }
    }
}
