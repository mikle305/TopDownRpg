using System;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    private Rigidbody2D _rb;
    private Animator _animator;
    private SpriteRenderer _sprite;


    public void Move(Vector2 direction)
    {
        ActionOnDirection(direction.x, direction.y);
        _rb.velocity = new Vector2(_speed * direction.x, _speed * direction.y);
    }

    private void Start()
    {
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
                    // Idle
                    break;
                }
            case (0.0f, -1.0f):
                {
                    // Down
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
}
