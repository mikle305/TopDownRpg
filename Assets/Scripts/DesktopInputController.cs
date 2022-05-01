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

    

    private void Update()
    {
        _playerMovement.Move(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
    }
}
