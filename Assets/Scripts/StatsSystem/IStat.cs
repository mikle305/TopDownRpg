using UnityEngine;
using System;

public interface IStat
{  
    public float Value { get; }

    public event Action ValueChanged;
}
