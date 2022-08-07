using System;

[Serializable]
public class GameData
{
    public GameDateTime Now { get; private set; }

    public GameData()
    {
        Now = new GameDateTime();
    }
}