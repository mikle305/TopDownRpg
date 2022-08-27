using UnityEngine;

namespace  Dependencies
{
    public class CharacterStatsMediator : MonoBehaviour
    {
        [Header("Stats dependencies")]
        [SerializeField] private CharacterStats _characterStats;
        [SerializeField] private CharacterMovement _characterMovement;
        [SerializeField] private StatBar _healthBar;
        [SerializeField] private StatBar _staminaBar;
        [SerializeField] private StatBar _satietyBar;

        [Header("Stats default values")]
        [SerializeField] private float _baseHealth;
        [SerializeField] private float _baseMaxHealth;
        [SerializeField] private float _baseStamina;
        [SerializeField] private float _baseMaxStamina;
        [SerializeField] private float _baseSatiety;
        [SerializeField] private float _baseMaxSatiety;
        [SerializeField] private float _baseSpeed;

        private DefaultStat _health;
        private ModifiableStat _maxHealth;
        private DefaultStat _stamina;
        private ModifiableStat _maxStamina;
        private DefaultStat _satiety;
        private ModifiableStat _maxSatiety;
        private ModifiableStat _speed;


        private void Start()
        {
            CreateStats();
            SetInteractionWithComponents();
            SetInteractionWithUI();
            SetStatsValues();
        }

        private void CreateStats()
        {
            _health = new DefaultStat();
            _maxHealth = new ModifiableStat();
            _stamina = new DefaultStat();
            _maxStamina = new ModifiableStat();
            _satiety = new DefaultStat();
            _maxSatiety = new ModifiableStat();
            _speed = new ModifiableStat();
        }

        private void SetStatsValues()
        {
            _health.Value = _baseHealth;
            _maxHealth.BaseValue = _baseMaxHealth;
            _stamina.Value = _baseStamina;
            _maxStamina.BaseValue = _baseMaxStamina;
            _satiety.Value = _baseSatiety;
            _maxSatiety.BaseValue = _baseMaxSatiety;
            _speed.BaseValue = _baseSpeed;
        }

        private void SetInteractionWithComponents()
        {
            _characterStats.InitHealth(_health, _maxHealth);
            _characterStats.InitStamina(_stamina, _maxStamina);
            _characterStats.InitSatiety(_satiety, _maxSatiety);
            _characterStats.InitSpeed(_speed);
            _characterMovement.InitSpeed(_speed);
        }

        private void SetInteractionWithUI()
        {
            _healthBar.InitStats(_health, _maxHealth);
            _staminaBar.InitStats(_stamina, _maxStamina);
            _satietyBar.InitStats(_satiety, _maxSatiety);
        }
    }
}
