using System;
using UnityEngine;

public class CharacterAnimation: MonoBehaviour
{
    private Animator _animator;

    private SpriteRenderer _sprite;

    public void Init(SpriteRenderer sprite)
    {
        _sprite = sprite;
    }

    public void Animate(Vector2 direction)
    {
        if (direction.x < 0.0f)
            _sprite.flipX = true;
        else if (direction.x > 0.0f)
            _sprite.flipX = false;
        switch (Mathf.Abs(direction.x), direction.y)
        {
            case (0.0f, 0.0f):
            {
                SetState(State.Idle);
                break;
            }
            case (0.0f, -1.0f):
            {
                SetState(State.WalkDown);
                break;
            }
            case (0.0f, 1.0f):
            {
                SetState(State.WalkUp);
                break;
            }
            case (1.0f, 0.0f):
            {
                SetState(State.WalkSide);
                break;
            }
            case (1.0f, -1.0f):
            {
                SetState(State.WalkSideDown);
                break;
            }
            case (1.0f, 1.0f):
            {
                SetState(State.WalkSideUp);
                break;
            }
        }
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private State GetState()
    {
        return (State)_animator.GetInteger("State");
    }

    private void SetState(State state)
    {
        _animator.SetInteger("State", (int)state);
    }

    private enum State
    {
        Idle = 0,
        WalkSide = 1,
        WalkDown = 2,
        WalkUp = 3,
        WalkSideDown = 4,
        WalkSideUp = 5
    }
}