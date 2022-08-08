using System;

public static class GameTime
{
    private static DateTime _now;
    
    public static DateTime Now => _now;

    public static void InitGameTime(DateTime gameTime)
    {
        _now = gameTime;
    }

    public static void OnGameTimeUpdated(double days)
    {
        _now = _now.AddDays(days);
    }
}