using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _attackRange;
    [SerializeField] private float _attackDelay;
    [SerializeField] private LayerMask _enemyMask;
    [SerializeField] private Animator _animator;

    private float time = 0;

    private void Update()
    {
        time += Time.deltaTime;

        if (time >= _attackDelay)
        {
            StartCoroutine(Attack());
            time = 0;
        }

    }

    private IEnumerator Attack()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position + new Vector3(0, 1, 0), _attackRange, _enemyMask);

        foreach (var enemy in hitEnemies)
        {
            if (Vector3.Distance(enemy.transform.position, transform.position) <= _attackRange)
            {
                if(enemy.GetComponent<Collider>().enabled)
                {
                    _animator.SetTrigger("attack");
                    enemy.GetComponent<Enemy>().ApplyDamage(_damage);
                    yield return new WaitForSeconds(_attackDelay);
                }
            }
            else
            {
                StopCoroutine(Attack());
                yield return (time = 0);
            }

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position + new Vector3(0, 1, 0), _attackRange);
    }
}
