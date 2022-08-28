using System;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(SpriteRenderer))]
public class Highlighter: MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private Color _targetColor;
    private Color _defaultColor;
    
    private SpriteRenderer _sprite;
    private Tweener _tweener;

    public void Do()
    {
        _tweener?.Kill();
        _tweener = _sprite.DOColor(_targetColor, _duration);
    }

    public void Undo()
    {
        _tweener?.Kill();
        _tweener = _sprite.DOColor(_defaultColor, _duration);
    }

    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _defaultColor = _sprite.color;
    }
}
