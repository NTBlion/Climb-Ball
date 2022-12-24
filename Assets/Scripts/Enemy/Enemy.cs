using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator), typeof(NavMeshAgent), typeof(BoxCollider))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Gem _gemTemplate;
    [SerializeField] private float _health = 1;
    [SerializeField] private float _damage = 1;
    [SerializeField] private float _attackDelay = 1;
    [SerializeField] private int _minGemValue = 1;
    [SerializeField] private int _maxGemValue = 4;

    private EnemyWeapon _weapon;
    private NavMeshAgent _agent;
    private Animator _animator;
    private BoxCollider _boxCollider;

    private Vector3 _offsetY = new Vector3(0, 1, 0);

    private int _gemsDropCount;

    public float Health => _health;
    public float Damage => _damage;
    public float AttackDelay => _attackDelay;
    public NavMeshAgent Agent => _agent;
    public Animator Animator => _animator;
    public BoxCollider BoxCollider => _boxCollider;
    public EnemyWeapon Weapon => _weapon;

    private void OnValidate()
    {
        if (_health <= 0)
            _health = 1;

        if (_damage <= 0)
            _damage = 1;

        if (_attackDelay <= 0)
            _attackDelay = 1;

        if (_minGemValue <= 0)
        {
            _minGemValue = 1;
        }
    }

    private void Awake()
    {
        _gemsDropCount = Random.Range(_minGemValue, _maxGemValue);

        _boxCollider = GetComponent<BoxCollider>();
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _weapon = GetComponentInChildren<EnemyWeapon>();
    }

    public void ApplyDamage(float damage)
    {
        _health -= damage;
    }

    public void DropGem()
    {
        for (int i = 0; i < _gemsDropCount; i++)
        {
            Instantiate(_gemTemplate, transform.position + _offsetY, Quaternion.identity);
        }
    }
}
