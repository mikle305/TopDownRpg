using UnityEngine;

public class CharacterStatsDependencies: MonoBehaviour
{
    [SerializeField]
    private Character _character;
    [SerializeField]
    private StatBar _healthBar;

    private void Start()
    {
        _healthBar.InitStats(_character.Health, _character.MaxHealth);
    }
}
