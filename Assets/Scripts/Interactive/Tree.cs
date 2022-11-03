using UnityEngine;

public class Tree: MonoBehaviour
{
    [Tooltip("In seconds")] [SerializeField] private float _destroyDuration;
    [SerializeField] private Damageable _damageable;
    [SerializeField] private Shaker _shaker;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private TreeFall _treeFall;
    
    private void Start()
    {
        _damageable.Damaged += OnDamaged;
        _damageable.Broken += OnBroken;
        _damageable.Destroyed += OnDestroyed;
    }

    private void OnDamaged(float damage)
    {
        _shaker.Shake();
    }

    private void OnBroken()
    {
        var tweener = _treeFall.Fall();
        tweener.onComplete += () => _damageable.Destroy(_destroyDuration);
    }

    private void OnDestroyed()
    {
        _spawner.Spawn();
    }

    private void OnDestroy()
    {
        _damageable.Damaged -= OnDamaged;
        _damageable.Broken -= OnBroken;
        _damageable.Destroyed -= OnDestroyed;
    }
}