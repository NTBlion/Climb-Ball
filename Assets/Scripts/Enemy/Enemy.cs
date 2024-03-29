using System;
using PickUp;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace Enemy
{
    [RequireComponent(typeof(Animator), typeof(NavMeshAgent), typeof(SphereCollider))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private Gem _gemTemplate;
        [SerializeField] private float _health = 1;
        [SerializeField] private float _damage = 1;
        [SerializeField] private float _attackDelay = 1;
        [SerializeField] private int _minGemValue = 1;
        [SerializeField] private int _maxGemValue = 4;

        
        private int _gemsDropCount;

        private EnemyWeapon _weapon;
        private NavMeshAgent _agent;
        private Animator _animator;
        private SphereCollider _collider;

        private Vector3 _offsetY = new Vector3(0, 1, 0);


        public UnityAction TookDamage;

        public bool CanBeHit { get; set; }
        public float Health => _health;
        public float Damage => _damage;
        public float AttackDelay => _attackDelay;
        public NavMeshAgent Agent => _agent;
        public Animator Animator => _animator;
        public SphereCollider Collider => _collider;
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

            _collider = GetComponent<SphereCollider>();
            _agent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<Animator>();
            _weapon = GetComponentInChildren<EnemyWeapon>();
        }

        public void ApplyDamage(float damage)
        {
            TookDamage?.Invoke();
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
}