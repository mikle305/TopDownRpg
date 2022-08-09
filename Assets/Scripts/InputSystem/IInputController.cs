using System;
using UnityEngine;

public interface IInputController
{
    public event Action<Vector2> DirectionCmdReceived;

    public event Action<Vector2> ActionCmdReceived;

    public event Action EscapeCmdReceived;
}
