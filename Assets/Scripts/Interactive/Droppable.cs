using DG.Tweening;
using UnityEngine;

public class Droppable: MonoBehaviour
{
    [Header("Movement info")] 
    [SerializeField] private float _duration;
    [SerializeField] private Vector2 _minDeflection;
    [SerializeField] private Vector2 _maxDeflection;

    private void Start()
    {
        Vector3 startPosition = transform.position;
        Vector3 endPosition = new Vector3(
            startPosition.x + Random.Range(_minDeflection.x, _maxDeflection.x),
            startPosition.y + Random.Range(_minDeflection.y, _maxDeflection.y)
        );
        transform.DOMove(endPosition, _duration);
    }
}