using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner: MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private bool _isInParent = true;
    
    [Header("Random count")]
    [SerializeField] private int _minCount;
    [SerializeField] private int _maxCount;
    
    [Header("Random spawn position")]
    [SerializeField] private Vector2 _minDeflection;
    [SerializeField] private Vector2 _maxDeflection;

    public void Spawn()
    {
        var count = Random.Range(_minCount, _maxCount);

        for (var i = 0; i < count; i++)
        {
            var deflection = new Vector3(
                Random.Range(_minDeflection.x, _maxDeflection.x), 
                Random.Range(_minDeflection.y, _maxDeflection.y)
                );
            SpawnOne(transform.position + deflection);
        }
    }

    protected virtual void SpawnOne(Vector3 position)
    {
        if (_isInParent)
            Instantiate(_prefab, position, Quaternion.identity, transform.parent);
        else
            Instantiate(_prefab, position, Quaternion.identity);
    }
}