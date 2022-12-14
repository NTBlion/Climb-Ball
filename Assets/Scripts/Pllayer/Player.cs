using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health = 1;
    [SerializeField] private float _maxHealth = 1;

    private CharacterController _characterController;

    public float Health => _health;

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
        _characterController = gameObject.GetComponent<CharacterController>();
        _characterController.detectCollisions = false;
    }

    public void ApplyDamage(float damage)
    {
        _health -= damage;

        if (_health <= 0)
            Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
