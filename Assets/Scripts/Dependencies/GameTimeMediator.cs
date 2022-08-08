using UnityEngine;

namespace Dependencies
{
    public class GameTimeMediator: MonoBehaviour
    {
        [SerializeField] private GameTimeUpdater _gameTimeUpdater;
        [SerializeField] private GameTimeText _gameTimeText;

        private void Start()
        {
            _gameTimeUpdater.GameTimeUpdated += GameTime.OnGameTimeUpdated;
            _gameTimeUpdater.GameTimeUpdated += _gameTimeText.OnGameTimeUpdated;
        }
    }
}