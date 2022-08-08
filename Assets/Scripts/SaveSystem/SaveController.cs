public class SaveController
{
    private IStorage<GameData> _gameDataStorage;

    public SaveController(IStorage<GameData> gameDataStorage)
    {
        _gameDataStorage = gameDataStorage;
    }

    public void Load()
    {
        LoadGameData();
    }

    public void Save()
    {
        SaveGameData();
    }

    private void LoadGameData()
    {
        var gameData = _gameDataStorage.Load();
        GameTime.InitGameTime(gameData.GameTime);
    }

    private void SaveGameData()
    {
        _gameDataStorage.Save(new GameData {
            GameTime = GameTime.Now
        });
    }
}