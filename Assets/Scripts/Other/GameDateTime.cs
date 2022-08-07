using System;

[Serializable]
public class GameDateTime
{
    private int _years;
    private int _months;
    private int _days;
    private int _hours;
    private int _minutes;
    private int _seconds;
    private int _milliseconds;
    private static GameDateTime _now;

    public int Years
    {
        get => _years;
        set => _years = value;
    }

    public int Months
    {
        get => _months;
        set
        {
            if (value >= 12)
                throw new Exception("Months must be less than 12");
            if (value < 0)
                throw new Exception("Months must be more than 0");
            _months = value;
        }
    }

    public int Days
    {
        get => _days;
        set
        {
            if (value >= 31)
                throw new Exception("Days must be less than 31");
            if (value < 0)
                throw new Exception("Days must be more than 0");
            _days = value;
        }
    }

    public int Hours
    {
        get => _hours;
        set
        {
            if (value >= 24)
                throw new Exception("Hours must be less than 24");
            if (value < 0)
                throw new Exception("Hours must be more than 0");
            _hours = value;
        }
    }
    
    public int Minutes
    {
        get => _minutes;
        set
        {
            if (value >= 60)
                throw new Exception("Minutes must be less than 60");
            if (value < 0)
                throw new Exception("Minutes must be more than 0");
            _minutes = value;
        }
    }

    public int Seconds
    {
        get => _seconds;
        set
        {
            if (value >= 60)
                throw new Exception("Seconds must be less than 60");
            if (value < 0)
                throw new Exception("Seconds must be more than 0");
            _seconds = value;
        }
    }

    public int MilliSeconds
    {
        get => _milliseconds;
        set
        {
            if (value >= 1000)
                throw new Exception("Milliseconds must be less than 1000");
            if (value < 0)
                throw new Exception("Milliseconds must be more than 0");
            _milliseconds = value;
        }
    }

    public static GameDateTime Now => _now.DeepCopy();
    
    public static IStorage<GameData> Storage { private get; set; }

    public static GameDateTime Parse(string s)
    {
        DateTime dateTime = DateTime.Parse(s);
        return Convert(dateTime);
    }

    public static GameDateTime Convert(DateTime dateTime)
    {
        return new GameDateTime
        {
            Years = dateTime.Year, 
            Months = dateTime.Month, 
            Days = dateTime.Day,
            Hours = dateTime.Hour,
            Minutes = dateTime.Minute,
            Seconds = dateTime.Second,
            MilliSeconds = dateTime.Millisecond
        };
    }

    static GameDateTime()
    {
        _now = Storage.Load().Now;
    }
}
