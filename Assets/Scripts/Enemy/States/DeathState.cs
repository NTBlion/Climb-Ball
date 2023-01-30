using System.Collections;
using Enemy.StateMachine;
using UnityEngine;

namespace Enemy.States
{
    public class DeathState : EnemyState
    {
        private Vector2 _moveDirection;
        private float _delayBeforeDestroy = 5f;

        private void OnEnable()
        {
            StartCoroutine(Die());
            _moveDirection = new Vector2(0, -0.15f);
        }

        private IEnumerator Die()
        {
            Enemy.BoxCollider.enabled = false;
            Enemy.Agent.enabled = false;
            Enemy.Animator.SetTrigger("die");
            Enemy.DropGem();
            StartCoroutine(Dissolve());
            yield return new WaitForSeconds(_delayBeforeDestroy);
            Destroy(Enemy.gameObject);
        }

        private IEnumerator Dissolve()
        {
            for (float i = 0; i < _delayBeforeDestroy; i += Time.deltaTime)
            {
                Enemy.transform.Translate(_moveDirection * Time.deltaTime);
                yield return null;
            }
        }
    }
}
