using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private ModifiableStat _speed;

    private Rigidbody2D _rigidbody;


    public void Move(Vector2 direction)
    {
        float x = direction.x;
        float y = direction.y;
        if (Mathf.Abs(direction.x) > 0 && Mathf.Abs(direction.y) > 0) 
        {
            x /= 2;
            y /= 2;
        }
        _rigidbody.velocity = new Vector2(_speed.GetValue() * x, _speed.GetValue() * y);
	}

    public void InitSpeed(ModifiableStat speed)
    {
        _speed = speed;
    }


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
}
