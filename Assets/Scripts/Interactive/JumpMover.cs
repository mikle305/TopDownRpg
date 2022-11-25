using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class JumpMover : MonoBehaviour
{
    [Tooltip("In seconds")] [SerializeField]
    private float _duration;

    [SerializeField] private float _jumpForce;
    [SerializeField] private int _jumpsCount = 1;

    [Header("Random position")] 
    [SerializeField] private Vector2 _minDeflection;
    [SerializeField] private Vector2 _maxDeflection;


    private void Start()
    {
        Move();
    }

    private void Move()
    {
        Vector3 startPosition = transform.position;
        var randomPosition = new Vector2(
            startPosition.x + Random.Range(_minDeflection.x, _maxDeflection.x),
            startPosition.y + Random.Range(_minDeflection.y, _maxDeflection.y));

        transform.DOJump(
            randomPosition,
            _jumpForce, 
            _jumpsCount, 
            _duration);
    }
}