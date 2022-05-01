using UnityEngine;
using System;

public class DesktopInputController : MonoBehaviour, IInputController
{
    private CharacterMovement _playerMovement;
    private Vector2 _movementDirection;

    public CharacterMovement PlayerMovement { set => _playerMovement = value; }
    

    private void Start()
    {
        _movementDirection = Vector2.zero;
    }

    // After Start()
    private void Awake()
    {
        if (_playerMovement is null)
            throw new NullReferenceException("Player Movement hasn't been initialized");
    }

    private void FixedUpdate()
    {
        _playerMovement.Move(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
    }
}
