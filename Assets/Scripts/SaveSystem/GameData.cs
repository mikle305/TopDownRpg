using System;

[Serializable]
public class GameData
{
    public DateTime GameTime { get; set; }

    public GameData()
    {
        GameTime = DateTime.MinValue;
    }
}