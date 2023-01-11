using UnityEngine;
using UnityEngine.Events;

public class PlayerAttack : MonoBehaviour, IUpgradable
{
    [SerializeField] private float _damage;
    [SerializeField] private float _additionalDamage;
    [SerializeField] private float _attackRange;
    [SerializeField] private float _attackDelay;
    [SerializeField] private LayerMask _enemyMask;
    [SerializeField] private PlayerAnimator _playerAnimator;

    private Vector3 _offset = new Vector3(0, 1, 0);
    public Collider[] _hitEnemies;

    private float _time = 0;

    private void Update()
    {
        _time += Time.deltaTime;

        _hitEnemies = Physics.OverlapSphere(transform.position + _offset, _attackRange, _enemyMask);

        if (_time > _attackDelay)
        {
            foreach (var enemy in _hitEnemies)
            {
                if (Vector3.Distance(enemy.transform.position, transform.position) <= _attackRange)
                {
                    if (enemy.GetComponent<Collider>().enabled)
                    {
                        enemy.GetComponent<Enemy>().ApplyDamage(_damage);
                        _time = 0;
                    }
                }
            }
        }


    }
    public void Upgrade()
    {
        _damage += _additionalDamage;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position + _offset, _attackRange);
    }

}
