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
        if (x < 0.0f)
            _sprite.flipX = true;
        else if (x > 0.0f)
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
                    _animState = AnimState.WalkUp;
                    break;
                }
            case (1.0f, 0.0f):
                {
                    _animState = AnimState.WalkSide;
                    break;
                }
            case (1.0f, -1.0f):
                {
                    _animState = AnimState.WalkSideDown;
                    break;
                }
            case (1.0f, 1.0f):
                {
                    _animState = AnimState.WalkSIdeUp;
                    break;
                }
        }
    }

    public enum AnimState
    {
        Idle = 0, 
        WalkSide = 1,
        WalkDown = 2,
        WalkUp = 3,
        WalkSideDown = 4,
        WalkSIdeUp = 5
    }
}
