using System;
using UnityEngine;

public class DesktopInputController : MonoBehaviour, IInputController
{
    private Vector2 _direction;
    public event Action<Vector2> DirectionCmdReceived;

    public event Action<Vector2> ActionCmdReceived;

    private void Start()
    {
        _direction = Vector2.zero;
    }

    private void Update()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        DirectionCmdReceived?.Invoke(_direction);
        if (Input.GetButton("Fire1"))
            ActionCmdReceived?.Invoke(_direction);
    }
}
