using System.Collections;
using UnityEngine;

public class MeleeAttackState : EnemyState
{
    private Coroutine _attackJob;

    private void OnEnable()
    {
        _attackJob = StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        while (Enemy.enabled)
        {
            Enemy.Animator.SetTrigger("attack");
            yield return new WaitForSeconds(Enemy.AttackDelay);
            if (Player != null)
                Player.ApplyDamage(Enemy.Damage);
        }
    }

    private void Update()
    {
        if (Player != null)
            Enemy.transform.LookAt(Player.transform); //Позже переделать, чтобы плавнее поворачивался
    }

    private void OnDisable()
    {
        StopCoroutine(_attackJob);
    }
}
