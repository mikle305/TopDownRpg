using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    private Rigidbody2D _rb;
    
    private SpriteRenderer _sprite;

    private CharacterAnim _characterAnim;


    public void Move(Vector2 direction)
    {
        
        AnimOnDirection(direction.x, direction.y);
        float x = direction.x;
        float y = direction.y;
        if (Mathf.Abs(direction.x) > 0 && Mathf.Abs(direction.y) > 0)
            x /= 2;
            y /= 2;
        _rb.velocity = new Vector2(_speed * x, _speed * y);
	}


    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sprite = GetComponentInChildren<SpriteRenderer>();
        _characterAnim = new CharacterAnim(GetComponent<Animator>(), CharacterAnim.AnimState.Idle);
    }
   
    private void AnimOnDirection(float x, float y)
    {
        if (x < 0.0f)
            _sprite.flipX = true;
        else if (x > 0.0f)
            _sprite.flipX = false;
        switch (Mathf.Abs(x), y)
        {
            case (0.0f, 0.0f):
                {
                    _characterAnim.State = CharacterAnim.AnimState.Idle;
                    break;
                }
            case (0.0f, -1.0f):
                {
                    _characterAnim.State = CharacterAnim.AnimState.WalkDown;
                    break;
                }
            case (0.0f, 1.0f):
                {
                    _characterAnim.State = CharacterAnim.AnimState.WalkUp;
                    break;
                }
            case (1.0f, 0.0f):
                {
                    _characterAnim.State = CharacterAnim.AnimState.WalkSide;
                    break;
                }
            case (1.0f, -1.0f):
                {
                    _characterAnim.State = CharacterAnim.AnimState.WalkSideDown;
                    break;
                }
            case (1.0f, 1.0f):
                {
                    _characterAnim.State = CharacterAnim.AnimState.WalkSIdeUp;
                    break;
                }
        }
    }
}
