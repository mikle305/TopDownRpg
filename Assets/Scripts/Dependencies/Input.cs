using UnityEngine;

namespace Assets.Scripts.Dependencies
{
    public class Input: MonoBehaviour
    {
        [SerializeField]
        private IInputController _inputController;

        [SerializeField]
        private CharacterMovement _characterMovement;

        [SerializeField]
        private CharacterAnimation _characterAnim;
    }
}
