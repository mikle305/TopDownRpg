﻿using System;
using UnityEngine;

namespace Dependencies
{
    public class InputMediator: MonoBehaviour
    {
        private IInputController _inputController;
        
        [SerializeField]
        private CharacterMovement _characterMovement;
        
        [SerializeField]
        private CharacterAnimation _characterAnimation;
        
        [SerializeField]
        private CharacterCombat _characterCombat;

        [SerializeField]
        private SpriteRenderer _sprite;

        private void Start()
        {

            #if UNITY_EDITOR || UNITY_STANDALONE
                _inputController = gameObject.AddComponent<DesktopInputController>();
            #else
               Debug.Log("Input for this platform doesn't support");
            #endif
            _characterAnimation.Init(_sprite);
            _inputController.DirectionCmdReceived += _characterMovement.Move;
            _inputController.DirectionCmdReceived += _characterAnimation.Animate;
            _inputController.ActionCmdReceived += _characterCombat.Attack;
        }
    }
}


