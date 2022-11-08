using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _attackRange;
    [SerializeField] private float _attackDelay;
    [SerializeField] private LayerMask _enemyMask;
    [SerializeField] private PlayerAnimator _playerAnimator;

    public Collider[] HitEnemies;

    private Vector3 _offset = new Vector3(0,1,0);
    private float _time = 0;

    private void Update()
    {
        _time += Time.deltaTime;

        if (_time > _attackDelay)
        {
            HitEnemies = Physics.OverlapSphere(transform.position + _offset, _attackRange, _enemyMask);
            foreach (var enemy in HitEnemies)
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

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position + _offset, _attackRange);
    }
}
