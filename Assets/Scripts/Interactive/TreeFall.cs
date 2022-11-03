using DG.Tweening;
using UnityEngine;

public class TreeFall: MonoBehaviour
{
    [Tooltip("In seconds")] [SerializeField] private float _duration;
    [Tooltip("In degrees")] [SerializeField] private float _angle;
    [Tooltip("In degrees")] [SerializeField] private float _minDeflection;
    [Tooltip("In degrees")] [SerializeField] private float _maxDeflection;
    
    public Tweener Fall()
    {
        var randomDeflection = Random.Range(_minDeflection, _maxDeflection);
        
        // Random left or right side with deflection
        var randomAngle = Random.Range(0, 2) == 0 
            ? new Vector3(0, 0, -1 * (_angle + randomDeflection)) 
            : new Vector3(0, 0, _angle + randomDeflection);
        
        return transform.DORotate(randomAngle, _duration);
    }
}