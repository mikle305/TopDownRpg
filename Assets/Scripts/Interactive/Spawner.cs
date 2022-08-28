using UnityEngine;

public class Spawner: MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _minCount;
    [SerializeField] private int _maxCount;
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
        Instantiate(_prefab, position, Quaternion.identity);
    }
}