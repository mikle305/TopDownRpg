using UnityEngine;

namespace Dependencies
{
    public class SaverMediator: MonoBehaviour
    {
        [SerializeField] private string _savePath;
        private IStorage<GameData> _storage;

        private void Start()
        {
            _storage = new FileStorage<GameData>(_savePath);
            GameDateTime.Storage = _storage;
        }
    }
}