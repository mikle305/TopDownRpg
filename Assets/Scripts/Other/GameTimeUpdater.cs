using System;
using UnityEngine;

public class GameTimeUpdater: MonoBehaviour
{
    [Tooltip("Real seconds for update Game Time")]
    [SerializeField] private float _updateDuration;
    
    [Tooltip("Duration of 1 game day in real seconds")]
    [SerializeField] private double _gameDayDuration;

    private float _updateTimer;

    public event Action<double> GameTimeUpdated;

    private void Update()
    {
        _updateTimer += Time.deltaTime;
        if (_updateTimer < _updateDuration) return;
        _updateTimer -= _updateDuration;
        GameTimeUpdated?.Invoke(1 / _gameDayDuration * _updateDuration);
    }
}