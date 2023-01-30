using System.Collections;
using Enemy.StateMachine;
using UnityEngine;

namespace Enemy.States
{
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

                if (Player != null && Player.Health >= 0)
                    Player.ApplyDamage(Enemy.Damage);
                else
                    StopCoroutine(Attack());
            }
        }

        private void Update()
        {
            if (Player != null)
                Enemy.transform.LookAt(Player.transform.position); //Позже переделать, чтобы плавнее поворачивался
        }

        private void OnDisable()
        {
            StopCoroutine(_attackJob);
        }
    }
}
