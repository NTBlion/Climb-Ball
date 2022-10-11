using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator), typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Gem _gemTemplate;
    [SerializeField] private float _health = 1;
    [SerializeField] private float _damage = 1;
    [SerializeField] private float _attackDelay = 1;

    private NavMeshAgent _agent;
    private Animator _animator;
    private int _gemsDropCount;

    public float Health => _health;
    public float Damage => _damage;
    public float AttackDelay => _attackDelay;
    public NavMeshAgent Agent => _agent;
    public Animator Animator => _animator;

    private void OnValidate()
    {
        if (_health <= 0)
            _health = 1;

        if (_damage <= 0)
            _damage = 1;

        if (_attackDelay <= 0)
            _attackDelay = 1;
    }

    private void Awake()
    {
        _gemsDropCount = Random.Range(1, 4);

        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    public void ApplyDamage(float damage)
    {
        _health -= damage;
    }

    public void DropGem()
    {
        for (int i = 0; i < _gemsDropCount; i++)
        {
            Instantiate(_gemTemplate, transform.position, Quaternion.identity);
        }
    }
}
