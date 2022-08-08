using UnityEngine;

namespace Dependencies
{
    public class SaveBootstrapper: MonoBehaviour
    {
        [SerializeField] private string _gameDataPath;
        [SerializeField] private float _autoSaveDuration;
        private SaveController _saveController;
        private float _autoSaveTimer;

        private void Start()
        {
            _saveController = new SaveController(new FileStorage<GameData>(_gameDataPath));
            _saveController.Load();
        }

        private void Update()
        {
            _autoSaveTimer += Time.deltaTime;
            if (_autoSaveTimer < _autoSaveDuration) return;
            _autoSaveTimer -= _autoSaveDuration;
            _saveController.Save();
        }
    }
}