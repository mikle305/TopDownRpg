using UnityEngine;
using System;

public class ProjectManager : MonoBehaviour
{
    [SerializeField]
    private Build _build;

    [SerializeField]
    private CharacterMovement _characterMovement;

    private IInputController _inputController;


    private void Start()
    {
        if (_build == Build.Desktop)
        { 
            _inputController = gameObject.AddComponent<DesktopInputController>(); 
        }
        else if (_build == Build.Android || _build == Build.IOS)
        {
            throw new Exception("This build type doesn't support");
            // _inputController = gameObject.AddComponent<MobileInputController>();
        }
        _inputController.PlayerMovement = _characterMovement;
    }

    public enum Build
    {
        Desktop,
        Android,
        IOS
    }
}
