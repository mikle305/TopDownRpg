using DG.Tweening;
using UnityEngine;

public class Shaker : MonoBehaviour
{
    [Tooltip("In seconds")] [SerializeField] private float _time;
    [SerializeField] private Vector2 _shakeStrength;
    
    private Tweener _tweener;
    private Vector3 _startScale;

    private void Start()
    {
        _startScale = transform.localScale;
    }

    public void Shake()
    { 
        _tweener?.Kill();
        transform.localScale = _startScale;
        _tweener = transform.DOShakeScale(_time, _shakeStrength);
    }

    public void Stop()
    {
        _tweener.Kill();
    }
}
