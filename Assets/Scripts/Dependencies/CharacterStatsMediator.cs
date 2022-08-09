using UnityEngine;

namespace  Dependencies
{
    public class CharacterStatsMediator : MonoBehaviour
    {
        [Header("Stats dependencies")]
        [SerializeField] private CharacterStats _characterStats;
        [SerializeField] private CharacterMovement _characterMovement;
        [SerializeField] private StatBarView _healthBar;
        [SerializeField] private StatBarView _staminaBar;
        [SerializeField] private StatBarView _satietyBar;

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
            InitStats();
            SetCharacterStats();
            SetStatBars();
            SetCharacterMovement();
        }

        private void InitStats()
        {
            _health = new DefaultStat(_baseHealth);
            _maxHealth = new ModifiableStat(_baseMaxHealth);
            _stamina = new DefaultStat(_baseStamina);
            _maxStamina = new ModifiableStat(_baseMaxStamina);
            _satiety = new DefaultStat(_baseSatiety);
            _maxSatiety = new ModifiableStat(_baseMaxSatiety);
            _speed = new ModifiableStat(_baseSpeed);
        }

        private void SetCharacterStats()
        {
            _characterStats.InitHealth(_health, _maxHealth);
            _characterStats.InitStamina(_stamina, _maxStamina);
            _characterStats.InitSatiety(_satiety, _maxSatiety);
            _characterStats.InitSpeed(_speed);
        }

        private void SetStatBars()
        {
            _healthBar.InitStats(_health, _maxHealth);
            _staminaBar.InitStats(_stamina, _maxStamina);
            _satietyBar.InitStats(_satiety, _maxSatiety);
        }

        private void SetCharacterMovement()
        {
            _characterMovement.InitSpeed(_speed);
        }
    }
}
