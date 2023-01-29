using UnityEngine;
using UnityEngine.Events;

public class PlayerAttack : MonoBehaviour, IUpgradable
{
    [SerializeField] private float _damage;
    [SerializeField] private float _additionalDamage;
    [SerializeField] private LayerMask _enemyMask;
    [SerializeField] private PlayerAnimator _playerAnimator;


    private float _attackDelay = 1f;
    private float _radius = 2f;
    private float _attackRange = 1.2f;
    private float _time = 0;

    private Vector3 _offset = new Vector3(0, 1, 0);
    private Collider[] _hitEnemies;

    public event UnityAction<Enemy> Attacked;

    public float AttackDelay => _attackDelay;

    private void FixedUpdate()
    {
        _hitEnemies = Physics.OverlapSphere(transform.position + _offset, _radius, _enemyMask);

        if (_time > _attackDelay)
        {
            foreach (var enemy in _hitEnemies)
            {
                if (Vector3.Distance(enemy.transform.position, transform.position) <= _attackRange)
                {
                    _playerAnimator.DoAnimation(PlayerAnimator.AnimationStates.attack);

                    var attackedEnemy = enemy.GetComponent<Enemy>();
                    Attacked?.Invoke(attackedEnemy);
                    attackedEnemy.ApplyDamage(_damage);

                    _time = 0;
                }
            }
        }
    }

    private void Update()
    {
        _time += Time.deltaTime;
    }

    public void Upgrade()
    {
        _damage += _additionalDamage;
    }
}
