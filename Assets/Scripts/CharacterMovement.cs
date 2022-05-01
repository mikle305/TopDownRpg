using System;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    private Rigidbody2D _rb;
    private Animator _animator;
    private SpriteRenderer _sprite;

    private AnimState _animState
    {
        get { return (AnimState)_animator.GetInteger("State"); }
        set { _animator.SetInteger("State", (int)value); }
    }


    public void Move(Vector2 direction)
    {
        _rb.velocity = _speed * direction;
    }

    private void Start()
    {
        _animState = AnimState.Idle;
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void ActionOnDirection(float x, float y)
    {
        if (x < 0)
            _sprite.flipX = true;
        else if (x > 0)
            _sprite.flipX = false;
        switch (Mathf.Abs(x), y)
        {
            case (0.0f, 0.0f):
                {
                    _animState = AnimState.Idle;
                    break;
                }
            case (0.0f, -1.0f):
                {
                    _animState = AnimState.WalkDown;
                    break;
                }
            case (0.0f, 1.0f):
                {
                    // Up
                    break;
                }
            case (1.0f, 0.0f):
                {
                    // Right
                    break;
                }
            case (1.0f, -1.0f):
                {
                    // Right down
                    break;
                }
            case (1.0f, 1.0f):
                {
                    // Right up
                    break;
                }
        }
    }

    public enum AnimState
    {
        Idle = 0,
        WalkUp = 1,
        WalkDown = 2
    }
}
