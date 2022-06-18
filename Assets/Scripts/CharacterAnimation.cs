using UnityEngine;

public class CharacterAnimation
{
    private Animator _animator;


    public AnimState State
    {
        private get => (AnimState)_animator.GetInteger("State"); 
        set => _animator.SetInteger("State", (int)value);
    }

    public CharacterAnimation(Animator animator, AnimState animState)
    {
        _animator = animator;
        State = animState;
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