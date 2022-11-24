using System;
using System.Collections;
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

    [Header("Random spawn delay in seconds")]
    [SerializeField] private float _minDelay;
    [SerializeField] private float _maxDelay;

    public event Action SpawnEnded;

    
    public void Spawn()
    {
        int count = Random.Range(_minCount, _maxCount + 1);
        var maxSpawnDelay = 0.0f;
        
        for (var i = 0; i < count; i++)
        {
            var deflection = new Vector3(
                Random.Range(_minDeflection.x, _maxDeflection.x), 
                Random.Range(_minDeflection.y, _maxDeflection.y));
            
            float delay = Random.Range(_minDelay, _maxDelay);
            if (delay > maxSpawnDelay)
                maxSpawnDelay = delay;
            
            StartCoroutine(SpawnOne(transform.position + deflection, delay));
        }

        StartCoroutine(InvokeSpawnEnded(maxSpawnDelay));
    }

    protected virtual IEnumerator SpawnOne(Vector3 position, float delay = 0.0f)
    {
        if (delay > 0.0f)
            yield return new WaitForSeconds(delay);
        
        if (_isInParent)
            Instantiate(_prefab, position, Quaternion.identity, transform.parent);
        else
            Instantiate(_prefab, position, Quaternion.identity);
    }

    private IEnumerator InvokeSpawnEnded(float delay)
    {
        yield return new WaitForSeconds(delay);
        
        SpawnEnded?.Invoke();
    }
}