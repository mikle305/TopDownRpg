using UnityEngine;

public class CharacterStatsDependencies: MonoBehaviour
{
    [SerializeField]
    private Character _character;
    [SerializeField]
    private StatBar _healthBar;
    [SerializeField]
    private StatBar _staminaBar;
    [SerializeField]
    private StatBar _satietyBar;

    [SerializeField]
    private float _baseHealth;
    [SerializeField]
    private float _baseMaxHealth;
    [SerializeField]
    private float _baseDamage;
    [SerializeField]
    private float _baseStamina;
    [SerializeField]
    private float _baseMaxStamina;
    [SerializeField]
    private float _baseSatiety;
    [SerializeField]
    private float _baseMaxSatiety;

    private DefaultStat _health;
    private ModifiableStat _maxHealth;
    private DefaultStat _stamina;
    private ModifiableStat _maxStamina;
    private DefaultStat _satiety;
    private ModifiableStat _maxSatiety;
    private ModifiableStat _damage;


    private void Start()
    {
        InitStats();
        SetCharacterStats();
        SetStatBars();
    }

    private void InitStats()
    {
        _health = new DefaultStat(_baseHealth);
        _maxHealth = new ModifiableStat(_baseMaxHealth);
        _stamina = new DefaultStat(_baseStamina);
        _maxStamina = new ModifiableStat(_baseMaxStamina);
        _satiety = new DefaultStat(_baseSatiety);
        _maxSatiety = new ModifiableStat(_baseMaxSatiety);
        _damage = new ModifiableStat(_baseDamage);
    }

    private void SetCharacterStats()
    {
        _character.Health = _health;
        _character.MaxHealth = _maxHealth;
        _character.Stamina = _stamina;
        _character.MaxStamina = _maxStamina;
        _character.Satiety = _satiety;
        _character.MaxSatiety = _maxSatiety;
        _character.Damage = _damage;
    }

    private void SetStatBars()
    {
        _healthBar.InitStats(_health, _maxHealth);
        _staminaBar.InitStats(_stamina, _maxStamina);
        _satietyBar.InitStats(_satiety, _maxSatiety);
    }
}
