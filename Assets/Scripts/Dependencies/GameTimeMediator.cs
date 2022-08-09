using System;
using UnityEngine;

namespace Dependencies
{
    public class GameTimeMediator: MonoBehaviour
    {
        [SerializeField] private GameTimeController _gameTimeController;
        [SerializeField] private GameTimeView _gameTimeView;

        private void Start()
        {
            _gameTimeController.GameTimeUpdated += GameTime.OnGameTimeUpdated;
            _gameTimeController.GameTimeUpdated += _gameTimeView.OnGameTimeUpdated;
        }

        private void OnDestroy()
        {
            _gameTimeController.GameTimeUpdated -= GameTime.OnGameTimeUpdated;
            _gameTimeController.GameTimeUpdated -= _gameTimeView.OnGameTimeUpdated;
        }
    }
}