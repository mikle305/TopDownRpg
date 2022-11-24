using System.Collections;
using DG.Tweening;
using UnityEngine;

public class TreeController: MonoBehaviour
{
    [Tooltip("In seconds")] [SerializeField] private float _destroyDelay;
    [SerializeField] private Damageable _damageable;
    [SerializeField] private Shaker _shaker;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private TreeFaller _treeFaller;
    
    
    private void Start()
    {
        _damageable.Damaged += OnDamaged;
        _damageable.Broken += OnBroken;
        _spawner.SpawnEnded += Destroy;
    }
    
    private void OnDestroy()
    {
        _damageable.Damaged -= OnDamaged;
        _damageable.Broken -= OnBroken;
    }

    private void OnDamaged(float damage)
    {
        _shaker.Shake();
    }

    private void OnBroken()
    {
        Tweener fallTweener = _treeFaller.Fall();
        fallTweener.onComplete += _spawner.Spawn;
    }
    
    private void Destroy()
    {
        StartCoroutine(InvokeDestroy(_destroyDelay));
    }

    private IEnumerator InvokeDestroy(float delay)
    {
        yield return new WaitForSeconds(delay);
        
        Destroy(gameObject);
    }
}