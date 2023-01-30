using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UpgradeSystem;

namespace Player
{
    public class Player : MonoBehaviour, IUpgradable
    {
        [SerializeField] private float _health = 1;
        [SerializeField] private float _maxHealth = 1;
        [SerializeField] private float _additionalHealth;
        [SerializeField] private PlayerAnimator _playerAnimator;

        public float Health => _health;

        public event UnityAction<float> HealthChanged;
        public event UnityAction PlayerDied;

        private void OnValidate()
        {
            if (_health <= 0)
                _health = 1;

            if (_maxHealth <= 0)
                _maxHealth = 1;

            if (_health > _maxHealth)
                _health = _maxHealth;
        }

        private void Awake()
        {
            _health = _maxHealth;
        }

        public void ApplyDamage(float damage)
        {
            _health -= damage;

            CalculateHealthAsPercentage();

            if (_health <= 0)
            {
                StartCoroutine(Die());
            }
        }

        public void Heal(float value)
        {
            _health += value;

            if (_health > _maxHealth)
                _health = _maxHealth;

            CalculateHealthAsPercentage();
        }

        public void Upgrade()
        {
            _maxHealth += _additionalHealth;
            CalculateHealthAsPercentage();
        }

        private void CalculateHealthAsPercentage()
        {
            var healthAsPercantage = _health / _maxHealth;
            HealthChanged?.Invoke(healthAsPercantage);
        }

        private IEnumerator Die()
        {
            PlayerDied?.Invoke();
            Debug.Log("сука");
            _playerAnimator.DoAnimation(PlayerAnimator.AnimationStates.die);
            yield return new WaitForSeconds(5f);
            Destroy(gameObject);
        }
    }

}
