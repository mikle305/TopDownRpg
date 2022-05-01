using UnityEngine;
using System;

public class DesktopInputController : MonoBehaviour, IInputController
{
    private CharacterMovement _characterMovement;
    private Vector2 _movementDirection;

    public CharacterMovement CharacterMovement { set => _characterMovement = value; }
    

    private void Start()
    {
        _movementDirection = Vector2.zero; 
    }

    private void Update()
    {
        _characterMovement.Move(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
    }
}
