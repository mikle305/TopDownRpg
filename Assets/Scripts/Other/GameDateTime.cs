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
    
    private static int _maxMonths;
    private static int _maxDays;
    private static int _maxHours;
    private static int _maxMinutes;
    private static int _maxSeconds;
    private static int _maxMilliseconds;
    
    private static GameDateTime _now;

    static GameDateTime()
    {
        _maxMonths = 12;
        _maxDays = 30;
        _maxHours = 24;
        _maxMinutes = 60;
        _maxSeconds = 60;
        _maxMilliseconds = 1000;
    }

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
            if (value >= _maxMonths)
                throw new Exception($"Months must be less than {_maxMonths}");
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
            if (value >= _maxDays)
                throw new Exception($"Days must be less than {_maxDays}");
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
            if (value >= _maxHours)
                throw new Exception($"Hours must be less than {_maxHours}");
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
            if (value >= _maxMinutes)
                throw new Exception($"Minutes must be less than {_maxMinutes}");
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
            if (value >= _maxSeconds)
                throw new Exception($"Seconds must be less than {_maxSeconds}");
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
            if (value >= _maxMilliseconds)
                throw new Exception($"Milliseconds must be less than {_maxMilliseconds}");
            if (value < 0)
                throw new Exception("Milliseconds must be more than 0");
            _milliseconds = value;
        }
    }

    public static GameDateTime Now => _now.DeepCopy();

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
    
    public static void InitNow(GameDateTime now)
    {
        _now = now;
    }
    
    public static void OnGameTimeUpdated(GameDateTime gameDateTime)
    {
        _now += gameDateTime;
    }

    public static GameDateTime operator + (GameDateTime gameDateTime1, GameDateTime gameDateTime2)
    {
        int years = gameDateTime1._years + gameDateTime2._years;
        int months = gameDateTime1._months + gameDateTime2._months;
        int days = gameDateTime1._days + gameDateTime2._days;
        int hours = gameDateTime1._hours + gameDateTime2._hours;
        int minutes = gameDateTime1._minutes + gameDateTime2._minutes;
        int seconds = gameDateTime1._seconds + gameDateTime2._seconds;
        int milliseconds = gameDateTime1._milliseconds + gameDateTime2._milliseconds;
        
        if (milliseconds / _maxMilliseconds == 1)
        {
            milliseconds %= _maxMilliseconds;
            seconds += 1;
        }
        if (seconds / _maxSeconds == 1)
        {
            seconds %= _maxSeconds;
            minutes += 1;
        }
        if (minutes / _maxMinutes == 1)
        {
            minutes %= _maxMinutes;
            hours += 1;
        }
        if (hours / _maxHours == 1)
        {
            hours %= _maxHours;
            days += 1;
        }
        if (days / _maxDays == 1)
        {
            days %= _maxDays;
            months += 1;
        }
        if (months / _maxMonths == 1)
        {
            months %= _maxMonths;
            years += 1;
        }

        return new GameDateTime
        {
            Years = years,
            Months = months,
            Days = days,
            Hours = hours,
            Minutes = minutes,
            Seconds = seconds,
            MilliSeconds = milliseconds
        };
    }
}
