using DG.Tweening;
using UnityEngine;

public class TreeFaller: MonoBehaviour
{
    [Tooltip("In seconds")] [SerializeField] private float _duration;
    [Tooltip("In degrees")] [SerializeField] private float _angle;
    [Tooltip("In degrees")] [SerializeField] private float _minDeflection;
    [Tooltip("In degrees")] [SerializeField] private float _maxDeflection;
    
    public Tweener Fall()
    {
        float randomDeflection = Random.Range(_minDeflection, _maxDeflection);
        
        // Random left or right side angle with random deflection
        Vector3 randomAngle = Random.Range(0, 2) == 0 
            ? new Vector3(0, 0, -1 * (_angle + randomDeflection)) 
            : new Vector3(0, 0, _angle + randomDeflection);
        
        return transform.DORotate(randomAngle, _duration);
    }
}