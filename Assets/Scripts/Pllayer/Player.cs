using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health = 1;
    [SerializeField] private float _maxHealth = 1;

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

        float healthAsPercantage = _health / _maxHealth;
        HealthChanged?.Invoke(healthAsPercantage);

        if (_health <= 0)
            Die();
    }

    public void Heal(float value)
    {
        _health += value;

        if (_health > _maxHealth)
            _health = _maxHealth;

        float healthAsPercantage = _health / _maxHealth;
        HealthChanged?.Invoke(healthAsPercantage);
    }

    private void Die()
    {
        PlayerDied?.Invoke();
        Destroy(gameObject);
    }
}
