using System;
using UnityEngine;

namespace Dependencies
{
    public class InputMediator: MonoBehaviour
    {
        [Header("Input dependencies")]
        [SerializeField] private CharacterMovement _characterMovement;
        [SerializeField] private CharacterAnimation _characterAnimation;
        [SerializeField] private CharacterCombat _characterCombat;

        private IInputController _inputController;

        private void Start()
        {

            #if UNITY_EDITOR || UNITY_STANDALONE
                _inputController = gameObject.AddComponent<DesktopInputController>();
            #else
               Debug.Log("Input for this platform doesn't support");
            #endif
            _inputController.DirectionCmdReceived += _characterMovement.Move;
            _inputController.DirectionCmdReceived += _characterAnimation.Animate;
            _inputController.ActionCmdReceived += _characterCombat.Attack;
        }

        private void OnDestroy()
        {
            _inputController.DirectionCmdReceived -= _characterMovement.Move;
            _inputController.DirectionCmdReceived -= _characterAnimation.Animate;
            _inputController.ActionCmdReceived -= _characterCombat.Attack;
        }
    }
}
